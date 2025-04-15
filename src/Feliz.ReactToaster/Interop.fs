namespace Feliz.ReactToaster

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    // importSideEffects "rc-slider/assets/index.css"
    let slider: obj = importDefault "react-toastify"

    let inline mkSliderProp (key: string) (value: obj) : ISliderProp = unbox (key, value)
    let inline mkDotStyleProp (key: string) (value: obj) : IDotStyleProp = unbox (key, value)
    let inline mkStyleProp (key: string) (value: obj) : ISliderStylesProp = unbox (key, value)
    let inline mkSliderTrackProp (key: string) (value: obj) : ISliderTrackProp = unbox (key, value)
