module Docs.Pages.Examples

open Feliz
open Feliz.DaisyUI
open Feliz.ReactToaster
open Docs.SharedView

[<ReactComponent>]
let ToastExamples () =
    Html.div [
        prop.className "flex flex-col gap-4"
        prop.children [
            Daisy.button.button [
                button.success
                prop.text "Success Toast"
                prop.onClick (fun _ -> ToastApi.successString "Operation completed successfully!" [] |> ignore)
            ]
            Daisy.button.button [
                button.error
                prop.text "Error Toast"
                prop.onClick (fun _ -> ToastApi.errorString "Something went wrong!" [] |> ignore)
            ]
            Daisy.button.button [
                button.info
                prop.text "Info Toast"
                prop.onClick (fun _ -> ToastApi.infoString "Here's some information for you." [] |> ignore)
            ]
            Daisy.button.button [
                button.warning
                prop.text "Warning Toast"
                prop.onClick (fun _ -> ToastApi.warningString "Be careful with this action!" [] |> ignore)
            ]
            ReactToaster.toastContainer [
                toastContainer.position Position.TopRight
                toastContainer.autoClose 5000
                toastContainer.hideProgressBar false
                toastContainer.closeOnClick true
                toastContainer.pauseOnHover true
                toastContainer.draggable true
                toastContainer.theme Theme.Light
                toastContainer.transition TransitionToast.bounce
            ]
        ]
    ]

let basicCode =
    """// Simple string toasts
ToastApi.successString "Operation completed!" []
ToastApi.errorString "Something went wrong!" []
ToastApi.infoString "Here's some info" []
ToastApi.warningString "Be careful!" []

// With custom options
ToastApi.successString "Saved!" [
    toast.position Position.BottomRight
    toast.autoClose 3000
    toast.theme Theme.Dark
]"""

let containerCode =
    """ReactToaster.toastContainer [
    toastContainer.position Position.TopRight
    toastContainer.autoClose 5000
    toastContainer.hideProgressBar false
    toastContainer.closeOnClick true
    toastContainer.pauseOnHover true
    toastContainer.draggable true
    toastContainer.theme Theme.Light
    toastContainer.transition TransitionToast.bounce
]"""

let elmishCode =
    """open Feliz.ReactToaster
open Elmish

let toast title message =
    ToastApi.message title message [
        toast.position Position.TopRight
        toast.autoClose 5000
        toast.theme Theme.Light
    ]

let errorToast title msg : Cmd<_> =
    toast title msg |> ToastApi.errorToast
let successToast title msg : Cmd<_> =
    toast title msg |> ToastApi.successToast

type Msg =
    | ShowError
    | ShowSuccess

let update msg model =
    match msg with
    | ShowError ->
        model, errorToast "Error" "Something went wrong!"
    | ShowSuccess ->
        model, successToast "Success" "Operation completed!" """

[<ReactComponent>]
let ExamplesView () =
    Html.div [
        Daisy.card [
            card.border
            prop.className "mb-8"
            prop.children [
                Daisy.cardBody [
                    Daisy.cardTitle "Basic Toast Examples"
                    Html.p [
                        prop.className "mb-4"
                        prop.text "Click the buttons below to see different toast types in action:"
                    ]
                    ToastExamples ()
                ]
            ]
        ]

        Html.h3 [
            prop.className "text-2xl font-bold mb-4"
            prop.text "Basic Usage"
        ]
        codedNoExampleView (Html.text "Simple toast functions") basicCode

        Html.h3 [
            prop.className "text-2xl font-bold mb-4 mt-8"
            prop.text "ToastContainer Configuration"
        ]
        codedNoExampleView (Html.text "Configure the container in your app") containerCode

        Html.h3 [
            prop.className "text-2xl font-bold mb-4 mt-8"
            prop.text "Elmish Integration"
        ]
        codedNoExampleView (Html.text "Use with Elmish commands") elmishCode
    ]
