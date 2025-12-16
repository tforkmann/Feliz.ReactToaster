namespace Feliz.ReactToaster

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Event = Browser.Types.Event

// The !! below is used to "unsafely" expose a prop into an ISliderProp.
[<Erase>]
type ReactToaster =

    static member inline toast(props: IToastProp seq) =
        ReactLegacy.createElement (Interop.toast, createObj !!props)
    static member inline toastContainer(props: IToastContainerProp seq) =
        ReactLegacy.createElement (Interop.toastContainer, createObj !!props)
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
    static member inline autoClose(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "autoClose" value
    static member inline hideProgressBar(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "hideProgressBar" value
    static member inline closeOnClick(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "closeOnClick" value
    static member inline pauseOnHover(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "pauseOnHover" value
    static member inline pauseOnFocusLoss(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "pauseOnFocusLoss" value
    static member inline draggable(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "draggable" value
    static member inline draggable(value: string) : IToastContainerProp = Interop.mkToastContainerProp "draggable" value
    static member inline draggablePercent(value: int) : IToastContainerProp = Interop.mkToastContainerProp "draggablePercent" value
    static member inline draggableDirection(direction: DraggableDirection) : IToastContainerProp =
        Interop.mkToastContainerProp "draggableDirection" direction
    static member inline limit(value: int) : IToastContainerProp = Interop.mkToastContainerProp "limit" value
    static member inline newestOnTop(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "newestOnTop" value
    static member inline rtl(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "rtl" value
    static member inline progress(value: float) : IToastContainerProp = Interop.mkToastContainerProp "progress" value
    static member inline theme(theme: Theme) : IToastContainerProp = Interop.mkToastContainerProp "theme" theme
    static member inline stacked(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "stacked" value
    static member inline containerId(id: string) : IToastContainerProp = Interop.mkToastContainerProp "containerId" id
    static member inline containerId(id: int) : IToastContainerProp = Interop.mkToastContainerProp "containerId" id
    static member inline className(value: string) : IToastContainerProp = Interop.mkToastContainerProp "className" value
    static member inline style(value: obj) : IToastContainerProp = Interop.mkToastContainerProp "style" value
    static member inline toastClassName(value: string) : IToastContainerProp = Interop.mkToastContainerProp "toastClassName" value
    static member inline bodyClassName(value: string) : IToastContainerProp = Interop.mkToastContainerProp "bodyClassName" value
    static member inline progressClassName(value: string) : IToastContainerProp = Interop.mkToastContainerProp "progressClassName" value
    static member inline closeButton(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "closeButton" value
    static member inline closeButton(value: ReactElement) : IToastContainerProp = Interop.mkToastContainerProp "closeButton" value
    static member inline icon(value: bool) : IToastContainerProp = Interop.mkToastContainerProp "icon" value
    static member inline icon(value: ReactElement) : IToastContainerProp = Interop.mkToastContainerProp "icon" value
    static member inline role(value: string) : IToastContainerProp = Interop.mkToastContainerProp "role" value

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
    static member inline autoClose(value: bool) : IToastProp = Interop.mkToastProp "autoClose" value
    static member inline hideProgressBar(value: bool) : IToastProp = Interop.mkToastProp "hideProgressBar" value
    static member inline newestOnTop(value: bool) : IToastProp = Interop.mkToastProp "newestOnTop" value
    static member inline closeOnClick(value: bool) : IToastProp = Interop.mkToastProp "closeOnClick" value
    static member inline pauseOnHover(value: bool) : IToastProp = Interop.mkToastProp "pauseOnHover" value
    static member inline pauseOnFocusLoss(value: bool) : IToastProp = Interop.mkToastProp "pauseOnFocusLoss" value
    static member inline draggable(value: bool) : IToastProp = Interop.mkToastProp "draggable" value
    static member inline draggable(value: string) : IToastProp = Interop.mkToastProp "draggable" value
    static member inline draggablePercent(value: int) : IToastProp = Interop.mkToastProp "draggablePercent" value
    static member inline draggableDirection(direction: DraggableDirection) : IToastProp =
        Interop.mkToastProp "draggableDirection" direction
    static member inline progress(value: float) : IToastProp = Interop.mkToastProp "progress" value
    static member inline theme(theme: Theme) : IToastProp = Interop.mkToastProp "theme" theme
    static member inline toastId(id: string) : IToastProp = Interop.mkToastProp "toastId" id
    static member inline toastId(id: int) : IToastProp = Interop.mkToastProp "toastId" id
    static member inline containerId(id: string) : IToastProp = Interop.mkToastProp "containerId" id
    static member inline containerId(id: int) : IToastProp = Interop.mkToastProp "containerId" id
    static member inline delay(ms: int) : IToastProp = Interop.mkToastProp "delay" ms
    static member inline className(value: string) : IToastProp = Interop.mkToastProp "className" value
    static member inline style(value: obj) : IToastProp = Interop.mkToastProp "style" value
    static member inline bodyClassName(value: string) : IToastProp = Interop.mkToastProp "bodyClassName" value
    static member inline progressClassName(value: string) : IToastProp = Interop.mkToastProp "progressClassName" value
    static member inline closeButton(value: bool) : IToastProp = Interop.mkToastProp "closeButton" value
    static member inline closeButton(value: ReactElement) : IToastProp = Interop.mkToastProp "closeButton" value
    static member inline icon(value: bool) : IToastProp = Interop.mkToastProp "icon" value
    static member inline icon(value: ReactElement) : IToastProp = Interop.mkToastProp "icon" value
    static member inline icon(value: string) : IToastProp = Interop.mkToastProp "icon" value
    static member inline isLoading(value: bool) : IToastProp = Interop.mkToastProp "isLoading" value
    static member inline data(value: obj) : IToastProp = Interop.mkToastProp "data" value
    static member inline role(value: string) : IToastProp = Interop.mkToastProp "role" value
    static member inline onClick(handler: unit -> unit) : IToastProp = Interop.mkToastProp "onClick" handler
    static member inline onOpen(handler: unit -> unit) : IToastProp = Interop.mkToastProp "onOpen" handler
    static member inline onClose(handler: unit -> unit) : IToastProp = Interop.mkToastProp "onClose" handler
    static member inline render(element: ReactElement) : IToastProp = Interop.mkToastProp "render" element
    static member inline toastType(toastType: ToastType) : IToastProp = Interop.mkToastProp "type" toastType

    static member inline transition (transition: obj) : IToastProp =
        Interop.mkToastProp "transition" transition

    static member inline children(children: ReactElement list) =
        unbox<IToastProp> (prop.children children)

[<Erase>]
module ToastApi =
    open Elmish

    type ToastId = string

    [<ReactComponent>]
    let toastView (title: string) (message: string) =
        Html.div [
            Html.strong [ prop.key "title"; prop.text title ]
            Html.p [ prop.key "message"; prop.text message ]
        ]

    let private callToast (method: string) (title: string) (message: string) (options: IToastProp seq) : ToastId =
        emitJsExpr (Interop.toast, method, toastView title message, keyValueList CaseRules.LowerFirst options) "$0[$1]($2, $3)"

    let private callToastSimple (method: string) (content: ReactElement) (options: IToastProp seq) : ToastId =
        emitJsExpr (Interop.toast, method, content, keyValueList CaseRules.LowerFirst options) "$0[$1]($2, $3)"

    let private callToastString (method: string) (message: string) (options: IToastProp seq) : ToastId =
        emitJsExpr (Interop.toast, method, message, keyValueList CaseRules.LowerFirst options) "$0[$1]($2, $3)"

    let info title message (props: IToastProp seq) : ToastId =
        callToast "info" title message props
    let success title message (props: IToastProp seq) : ToastId =
        callToast "success" title message props
    let error title message (props: IToastProp seq) : ToastId =
        callToast "error" title message props
    let warning title message (props: IToastProp seq) : ToastId =
        callToast "warning" title message props
    let warn title message (props: IToastProp seq) : ToastId =
        callToast "warn" title message props
    let defaultT title message (props: IToastProp seq) : ToastId =
        callToast "default" title message props

    let infoSimple (content: ReactElement) (props: IToastProp seq) : ToastId =
        callToastSimple "info" content props
    let successSimple (content: ReactElement) (props: IToastProp seq) : ToastId =
        callToastSimple "success" content props
    let errorSimple (content: ReactElement) (props: IToastProp seq) : ToastId =
        callToastSimple "error" content props
    let warningSimple (content: ReactElement) (props: IToastProp seq) : ToastId =
        callToastSimple "warning" content props
    let warnSimple (content: ReactElement) (props: IToastProp seq) : ToastId =
        callToastSimple "warn" content props
    let defaultSimple (content: ReactElement) (props: IToastProp seq) : ToastId =
        emitJsExpr (Interop.toast, content, keyValueList CaseRules.LowerFirst props) "$0($1, $2)"

    let infoString (message: string) (props: IToastProp seq) : ToastId =
        callToastString "info" message props
    let successString (message: string) (props: IToastProp seq) : ToastId =
        callToastString "success" message props
    let errorString (message: string) (props: IToastProp seq) : ToastId =
        callToastString "error" message props
    let warningString (message: string) (props: IToastProp seq) : ToastId =
        callToastString "warning" message props
    let warnString (message: string) (props: IToastProp seq) : ToastId =
        callToastString "warn" message props
    let defaultString (message: string) (props: IToastProp seq) : ToastId =
        emitJsExpr (Interop.toast, message, keyValueList CaseRules.LowerFirst props) "$0($1, $2)"

    let loading title message (props: IToastProp seq) : ToastId =
        callToast "loading" title message props
    let loadingSimple (content: ReactElement) (props: IToastProp seq) : ToastId =
        callToastSimple "loading" content props
    let loadingString (message: string) (props: IToastProp seq) : ToastId =
        callToastString "loading" message props

    let dismiss () : unit =
        emitJsExpr Interop.toast "$0.dismiss()"
    let dismissById (toastId: ToastId) : unit =
        emitJsExpr (Interop.toast, toastId) "$0.dismiss($1)"

    let isActive (toastId: ToastId) : bool =
        emitJsExpr (Interop.toast, toastId) "$0.isActive($1)"

    let update (toastId: ToastId) (props: IToastProp seq) : unit =
        emitJsExpr (Interop.toast, toastId, keyValueList CaseRules.LowerFirst props) "$0.update($1, $2)"

    let updateWithContent (toastId: ToastId) (content: ReactElement) (props: IToastProp seq) : unit =
        let options = keyValueList CaseRules.LowerFirst props
        emitJsExpr (options, content) "$0.render = $1"
        emitJsExpr (Interop.toast, toastId, options) "$0.update($1, $2)"

    let updateWithString (toastId: ToastId) (message: string) (props: IToastProp seq) : unit =
        let options = keyValueList CaseRules.LowerFirst props
        emitJsExpr (options, message) "$0.render = $1"
        emitJsExpr (Interop.toast, toastId, options) "$0.update($1, $2)"

    let ``done`` (toastId: ToastId) : unit =
        emitJsExpr (Interop.toast, toastId) "$0.done($1)"

    let clearWaitingQueue () : unit =
        emitJsExpr Interop.toast "$0.clearWaitingQueue()"
    let clearWaitingQueueById (containerId: string) : unit =
        emitJsExpr (Interop.toast, containerId) "$0.clearWaitingQueue({ containerId: $1 })"

    let play () : unit =
        emitJsExpr Interop.toast "$0.play()"
    let playById (toastId: ToastId) : unit =
        emitJsExpr (Interop.toast, toastId) "$0.play({ id: $1 })"

    let pause () : unit =
        emitJsExpr Interop.toast "$0.pause()"
    let pauseById (toastId: ToastId) : unit =
        emitJsExpr (Interop.toast, toastId) "$0.pause({ id: $1 })"

    type PromiseMessages = {
        Pending: string
        Success: string
        Error: string
    }

    let promise (promiseFunc: unit -> JS.Promise<'T>) (messages: PromiseMessages) (props: IToastProp seq) : JS.Promise<'T> =
        let msgs = {| pending = messages.Pending; success = messages.Success; error = messages.Error |}
        emitJsExpr (Interop.toast, promiseFunc(), msgs, keyValueList CaseRules.LowerFirst props) "$0.promise($1, $2, $3)"

    type ToastMsg<'a> = {
        Title : string
        Message : string
        Props: IToastProp seq
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
            error msg.Title msg.Message msg.Props |> ignore]
    let successToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            success msg.Title msg.Message msg.Props |> ignore]

    let infoToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            info msg.Title msg.Message msg.Props |> ignore]
    let warningToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            warning msg.Title msg.Message msg.Props |> ignore]
    let defaultToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            defaultT msg.Title msg.Message msg.Props |> ignore]
    let loadingToast (msg: ToastMsg<'msg>) :  Cmd<'msg> =
        [fun dispatch ->
            msg.Dispatcher <- Some dispatch
            loading msg.Title msg.Message msg.Props |> ignore]
