module Index

open Elmish
open Feliz
open Feliz.ReactToaster

type Model = { Txt: string }

type Msg = | ShowToast
let init () = { Txt = "" }, Cmd.none

let toast title message =
    ToastApi.message title message [
        toast.position Position.TopRight
        toast.autoClose 5000
        toast.newestOnTop false
        toast.hideProgressBar false
        toast.closeOnClick true
        toast.pauseOnHover true
        toast.draggable true
        toast.theme Theme.Light
        toast.transition TransitionToast.flip
    ]

let errorToast title message : Cmd<_> = toast title message |> ToastApi.errorToast
let successToast title message : Cmd<_> = toast title message |> ToastApi.successToast
let infoToast title message : Cmd<_> = toast title message |> ToastApi.infoToast

let update msg (model: Model) =
    match msg with
    | ShowToast -> model, infoToast "🦄 Wow so easy!" "Error"

let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        Html.h1 "Hello from ReactToaster"

        Html.button [
            prop.text "Notify !"
            prop.onClick (fun _ -> dispatch ShowToast)
            prop.className "btn btn-primary"
        ]

        ReactToaster.toastContainer [
            toastContainer.position Position.TopRight
            toastContainer.newestOnTop false
            toastContainer.autoClose 10000
            toastContainer.hideProgressBar true
            toastContainer.closeOnClick true
            toastContainer.pauseOnHover true
            toastContainer.draggable true
            toastContainer.rtl false
            toastContainer.theme Theme.Colored
            toastContainer.transition TransitionToast.bounce
        ]
    ]
