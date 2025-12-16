namespace Feliz.ReactToaster

open Fable.Core
open Fable.Core.JsInterop


[<Erase; RequireQualifiedAccess>]
module Interop =
    // Import the toast and toastContainer directly
    [<Import("toast", from="react-toastify")>]
    let toast: Feliz.ReactElement = jsNative

    let toastContainer: Feliz.ReactElement = import "ToastContainer" "react-toastify"

    let inline mkToastProp (key: string) (value: obj) : IToastProp = unbox (key, value)
    let inline mkToastContainerProp (key: string) (value: obj) : IToastContainerProp = unbox (key, value)

    let inline mkTransitionProp (key: string) (value: obj) : ITransition = unbox (key, value)

    let bounce : obj = import "Bounce" "react-toastify"
    let slide : obj = import "Slide" "react-toastify"
    let zoom : obj = import "Zoom" "react-toastify"
    let flip : obj = import "Flip" "react-toastify"
