namespace Feliz.ReactToaster

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Event = Browser.Types.Event

// The !! below is used to "unsafely" expose a prop into an ISliderProp.
[<Erase>]
type ReactToaster =

    static member inline toast(props: IToastProp seq) =
        Interop.reactApi.createElement (Interop.toast, createObj !!props)
    static member inline toastContainer(props: IToastContainerProp seq) =
        Interop.reactApi.createElement (Interop.toastContainer, createObj !!props)
    static member inline children(children: ReactElement list) =
        unbox<IToastProp> (prop.children children)

[<Erase>]
type TransitionToast =
    static member bounce = Interop.bounce
    static member slide = Interop.slide
    static member zoom = Interop.zoom
    static member flip = Interop.flip
    // static member fade = Interop.fade

[<Erase>]
type toastContainer =

    static member inline position(position: Position) : IToastContainerProp =
        match position with
        | Position.TopRight -> Interop.mkToastContainerProp "position" "top-right"
        | Position.TopLeft -> Interop.mkToastContainerProp "position" "top-left"
        | Position.BottomRight -> Interop.mkToastContainerProp "position" "bottom-right"
        | Position.BottomLeft -> Interop.mkToastContainerProp "position" "bottom-left"
        | Position.TopCenter -> Interop.mkToastContainerProp "position" "top-center"
        | Position.BottomCenter -> Interop.mkToastContainerProp "position" "bottom-center"
    static member inline autoClose(ms: int) : IToastContainerProp = Interop.mkToastContainerProp "autoClose" ms
    static member inline hideProgressBar(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "hideProgressBar" value
    static member inline closeOnClick(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "closeOnClick" value
    static member inline pauseOnHover(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "pauseOnHover" value
    static member inline draggable(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "draggable" value
    static member inline limit(value: int) : IToastContainerProp = Interop.mkToastContainerProp "limit" value
    static member inline newestOnTop(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "newestOnTop" value
    static member inline rtl(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "rtl" value
    static member inline progress(value: float) : IToastContainerProp = Interop.mkToastContainerProp "progress" value
    static member inline theme(theme: Theme) : IToastContainerProp = Interop.mkToastContainerProp "theme" theme

    static member inline transition (transition: obj) : IToastContainerProp =
        Interop.mkToastContainerProp "transition" transition
    static member inline children(children: ReactElement list) =
        unbox<IToastContainerProp> (prop.children children)

[<Erase>]
type toast =
    static member inline position(position: Position) : IToastProp =
        match position with
        | Position.TopRight -> Interop.mkToastProp "position" "top-right"
        | Position.TopLeft -> Interop.mkToastProp "position" "top-left"
        | Position.BottomRight -> Interop.mkToastProp "position" "bottom-right"
        | Position.BottomLeft -> Interop.mkToastProp "position" "bottom-left"
        | Position.TopCenter -> Interop.mkToastProp "position" "top-center"
        | Position.BottomCenter -> Interop.mkToastProp "position" "bottom-center"
    static member inline autoClose(ms: int) : IToastProp = Interop.mkToastProp "autoClose" ms
    static member inline hideProgressBar(value: bool) : IToastProp = Interop.mkToastProp "hideProgressBar" value
    static member inline newestOnTop(value: bool) : IToastProp = Interop.mkToastProp "newestOnTop" value
    static member inline closeOnClick(value: bool) : IToastProp = Interop.mkToastProp "closeOnClick" value
    static member inline pauseOnHover(value: bool) : IToastProp = Interop.mkToastProp "pauseOnHover" value
    static member inline draggable(value: bool) : IToastProp = Interop.mkToastProp "draggable" value
    static member inline progress(value: float) : IToastProp = Interop.mkToastProp "progress" value
    static member inline theme(theme: Theme) : IToastProp = Interop.mkToastProp "theme" theme

    static member inline transition (transition: obj) : IToastProp =
        Interop.mkToastProp "transition" transition

    static member inline children(children: ReactElement list) =
        unbox<IToastProp> (prop.children children)

[<Erase>]
module ToastApi =
    open Elmish
    [<ReactComponent>]
    let toastView (title: string) (message: string) =
        Html.div [
            prop.className "flex flex-col"
            prop.children [
                Html.strong [ prop.text title ]
                Html.p [ prop.text message ]
            ]
        ]
    let private callToast (method: string) (title: string) (message: string) (options: IToastProp seq) =
        emitJsExpr (Interop.toast, method, toastView title message, keyValueList CaseRules.LowerFirst options) "$0[$1]($2, $3)"

    let info title message (props: IToastProp seq) : unit =
        callToast "info" title message props
    let success title message (props: IToastProp seq) : unit =
        callToast "success" title message props
    let error title message (props: IToastProp seq) : unit =
        callToast "error" title message props
    let warning title message (props: IToastProp seq) : unit =
        callToast "warning" title message props
    let defaultT title message (props: IToastProp seq) : unit =
        callToast "default" title message props
    type ToastMsg<'a> = {
        Title : string
        Message : string
        Props: IToastProp  seq
        mutable Dispatcher : Option<'a -> unit>
    }

    let message title message props =
        {
            Title = title
            Message = message
            Props = props
            Dispatcher = None
        }

    let errorToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            error msg.Title msg.Message msg.Props]
    let successToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            success msg.Title msg.Message msg.Props]

    let infoToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            info msg.Title msg.Message msg.Props]
    let warningToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            warning msg.Title msg.Message msg.Props]
    let defaultToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            defaultT msg.Title msg.Message msg.Props]
