module Docs.Pages.Advanced

open Feliz
open Feliz.DaisyUI
open Feliz.ReactToaster
open Docs.SharedView

let mutable loadingToastId: ToastApi.ToastId option = None

[<ReactComponent>]
let AdvancedExamples () =
    Html.div [
        prop.className "flex flex-col gap-4"
        prop.children [
            Html.h4 [ prop.className "font-bold"; prop.text "Loading & Update" ]
            Html.div [
                prop.className "flex gap-2"
                prop.children [
                    Daisy.button.button [
                        button.primary
                        prop.text "Start Loading"
                        prop.onClick (fun _ ->
                            let id = ToastApi.loadingString "Loading data..." []
                            loadingToastId <- Some id
                        )
                    ]
                    Daisy.button.button [
                        button.success
                        prop.text "Complete Loading"
                        prop.onClick (fun _ ->
                            match loadingToastId with
                            | Some id ->
                                ToastApi.updateWithString id "Data loaded successfully!" [
                                    toast.toastType ToastType.Success
                                    toast.isLoading false
                                ]
                                loadingToastId <- None
                            | None -> ()
                        )
                    ]
                ]
            ]

            Html.h4 [ prop.className "font-bold mt-4"; prop.text "Toast Control" ]
            Html.div [
                prop.className "flex gap-2"
                prop.children [
                    Daisy.button.button [
                        button.secondary
                        prop.text "Dismiss All"
                        prop.onClick (fun _ -> ToastApi.dismiss ())
                    ]
                    Daisy.button.button [
                        button.ghost
                        prop.text "Pause All"
                        prop.onClick (fun _ -> ToastApi.pause ())
                    ]
                    Daisy.button.button [
                        button.ghost
                        prop.text "Play All"
                        prop.onClick (fun _ -> ToastApi.play ())
                    ]
                ]
            ]

            Html.h4 [ prop.className "font-bold mt-4"; prop.text "Transitions" ]
            Html.div [
                prop.className "flex gap-2 flex-wrap"
                prop.children [
                    Daisy.button.button [
                        button.outline
                        prop.text "Bounce"
                        prop.onClick (fun _ ->
                            ToastApi.successString "Bounce!" [
                                toast.transition TransitionToast.bounce
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.outline
                        prop.text "Slide"
                        prop.onClick (fun _ ->
                            ToastApi.successString "Slide!" [
                                toast.transition TransitionToast.slide
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.outline
                        prop.text "Zoom"
                        prop.onClick (fun _ ->
                            ToastApi.successString "Zoom!" [
                                toast.transition TransitionToast.zoom
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.outline
                        prop.text "Flip"
                        prop.onClick (fun _ ->
                            ToastApi.successString "Flip!" [
                                toast.transition TransitionToast.flip
                            ] |> ignore
                        )
                    ]
                ]
            ]

            Html.h4 [ prop.className "font-bold mt-4"; prop.text "Positions" ]
            Html.div [
                prop.className "flex gap-2 flex-wrap"
                prop.children [
                    Daisy.button.button [
                        button.xs
                        prop.text "Top Right"
                        prop.onClick (fun _ ->
                            ToastApi.infoString "Top Right!" [
                                toast.position Position.TopRight
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.xs
                        prop.text "Top Left"
                        prop.onClick (fun _ ->
                            ToastApi.infoString "Top Left!" [
                                toast.position Position.TopLeft
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.xs
                        prop.text "Top Center"
                        prop.onClick (fun _ ->
                            ToastApi.infoString "Top Center!" [
                                toast.position Position.TopCenter
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.xs
                        prop.text "Bottom Right"
                        prop.onClick (fun _ ->
                            ToastApi.infoString "Bottom Right!" [
                                toast.position Position.BottomRight
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.xs
                        prop.text "Bottom Left"
                        prop.onClick (fun _ ->
                            ToastApi.infoString "Bottom Left!" [
                                toast.position Position.BottomLeft
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.xs
                        prop.text "Bottom Center"
                        prop.onClick (fun _ ->
                            ToastApi.infoString "Bottom Center!" [
                                toast.position Position.BottomCenter
                            ] |> ignore
                        )
                    ]
                ]
            ]

            Html.h4 [ prop.className "font-bold mt-4"; prop.text "Themes" ]
            Html.div [
                prop.className "flex gap-2"
                prop.children [
                    Daisy.button.button [
                        button.sm
                        prop.text "Light"
                        prop.onClick (fun _ ->
                            ToastApi.successString "Light theme!" [
                                toast.theme Theme.Light
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.sm
                        prop.text "Dark"
                        prop.onClick (fun _ ->
                            ToastApi.successString "Dark theme!" [
                                toast.theme Theme.Dark
                            ] |> ignore
                        )
                    ]
                    Daisy.button.button [
                        button.sm
                        prop.text "Colored"
                        prop.onClick (fun _ ->
                            ToastApi.successString "Colored theme!" [
                                toast.theme Theme.Colored
                            ] |> ignore
                        )
                    ]
                ]
            ]

            ReactToaster.toastContainer [
                toastContainer.position Position.TopRight
                toastContainer.autoClose 3000
                toastContainer.hideProgressBar false
                toastContainer.closeOnClick true
                toastContainer.pauseOnHover true
                toastContainer.draggable true
                toastContainer.theme Theme.Light
                toastContainer.transition TransitionToast.bounce
            ]
        ]
    ]

let loadingCode =
    """// Show a loading toast
let toastId = ToastApi.loadingString "Loading data..." []

// Later, update it to success or error
ToastApi.updateWithString toastId "Data loaded!" [
    toast.toastType ToastType.Success
    toast.isLoading false
]"""

let controlCode =
    """// Dismiss all toasts
ToastApi.dismiss ()

// Dismiss specific toast
ToastApi.dismissById "my-toast-id"

// Check if toast is active
if ToastApi.isActive "my-toast-id" then
    // do something

// Pause/Play toasts
ToastApi.pause ()
ToastApi.play ()"""

let promiseCode =
    """let fetchData () =
    promise {
        // async operation
        return! someAsyncCall()
    }

ToastApi.promise
    fetchData
    { Pending = "Loading..."
      Success = "Done!"
      Error = "Failed!" }
    []"""

let stackedCode =
    """// Enable stacked mode (v11 feature)
ReactToaster.toastContainer [
    toastContainer.stacked true
    toastContainer.position Position.TopRight
]"""

let customCode =
    """// Custom options
ToastApi.successString "Custom toast!" [
    toast.position Position.BottomRight
    toast.autoClose 3000
    toast.theme Theme.Dark
    toast.icon "🎉"
    toast.onClick (fun _ -> printfn "Toast clicked!")
    toast.onClose (fun _ -> printfn "Toast closed!")
]"""

[<ReactComponent>]
let AdvancedView () =
    Html.div [
        Daisy.card [
            card.bordered
            prop.className "mb-8"
            prop.children [
                Daisy.cardBody [
                    Daisy.cardTitle "Advanced Examples"
                    Html.p [
                        prop.className "mb-4"
                        prop.text "Try out advanced toast features:"
                    ]
                    AdvancedExamples ()
                ]
            ]
        ]

        Html.h3 [
            prop.className "text-2xl font-bold mb-4"
            prop.text "Loading Toasts"
        ]
        codedNoExampleView (Html.text "Show loading state and update on completion") loadingCode

        Html.h3 [
            prop.className "text-2xl font-bold mb-4 mt-8"
            prop.text "Toast Control"
        ]
        codedNoExampleView (Html.text "Control toast display programmatically") controlCode

        Html.h3 [
            prop.className "text-2xl font-bold mb-4 mt-8"
            prop.text "Promise Integration"
        ]
        codedNoExampleView (Html.text "Automatically handle promise states") promiseCode

        Html.h3 [
            prop.className "text-2xl font-bold mb-4 mt-8"
            prop.text "Stacked Mode (v11)"
        ]
        codedNoExampleView (Html.text "Enable stacked toast display") stackedCode

        Html.h3 [
            prop.className "text-2xl font-bold mb-4 mt-8"
            prop.text "Custom Options"
        ]
        codedNoExampleView (Html.text "Customize individual toasts") customCode
    ]
