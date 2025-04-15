namespace Feliz.ReactToastify

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Event = Browser.Types.Event

// The !! below is used to "unsafely" expose a prop into an ISliderProp.
[<Erase>]
type ReactToastify =
    /// Creates a new Slider component.

    static member inline slider(props: ISliderProp seq) =
        Interop.reactApi.createElement (Interop.slider, createObj !!props)
    static member inline children(children: ReactElement list) =
        unbox<ISliderProp> (prop.children children)

[<Erase>]
type slider =
    static member inline range =
        Interop.mkSliderProp "range" isNullOrUndefined

    static member inline allowCross (allowCross: bool) =
        Interop.mkSliderProp "allowCross" allowCross
    static member inline min (value: int) =
        Interop.mkSliderProp "min" value
    static member inline max (value: int) =
        Interop.mkSliderProp "max" value
    static member inline min (value: float) =
        Interop.mkSliderProp "min" value
    static member inline max (value: float) =
        Interop.mkSliderProp "max" value

    static member inline onChange (handler: int -> unit) : ISliderProp =
        !!( "onChange" ==> System.Func<_,_>handler)

    static member inline onChangeRange (handler: int * int -> unit) : ISliderProp =
        !!( "onChange" ==> System.Func<_,_>handler)

    static member inline onChangeRangeFloats (handler: float * float -> unit) : ISliderProp =
        !!( "onChange" ==> System.Func<_,_>handler)
    static member inline step (value: int) =
        Interop.mkSliderProp "step" value
    static member inline step (value: float) =
        Interop.mkSliderProp "step" value
    static member inline stepNull  =
     Interop.mkSliderProp "step" isNullOrUndefined
    static member inline value (value: int) =
        Interop.mkSliderProp "value" value
    static member inline value (value: float) =
        Interop.mkSliderProp "value" value
    static member inline defaultValue (value: int) =
        Interop.mkSliderProp "defaultValue" value

    static member inline defaultValue (value: float) =
        Interop.mkSliderProp "defaultValue" value
    static member inline defaultValueRange (value: int * int) =
        Interop.mkSliderProp "defaultValue" value
    static member inline defaultValueRangeFloats (value: float * float) =
        Interop.mkSliderProp "defaultValue" value

    static member inline dots (value: bool) =
        Interop.mkSliderProp "dots" value
    static member inline disabled (value: bool) =
        Interop.mkSliderProp "disabled" value
    static member inline marks (marks: (int * ReactElement) seq) =
        Interop.mkSliderProp "marks" marks

    static member inline styles (props: ISliderStylesProp seq) = Interop.mkSliderProp "styles" (createObj !!props)
    static member inline dotStyle (props: IDotStyleProp seq) = Interop.mkSliderProp "dotStyle" (createObj !!props)
    static member inline activeDotStyle (props: IDotStyleProp seq) = Interop.mkSliderProp "activeDotStyle" (createObj !!props)

    static member inline marksWithStyle (values: (int * (string * ReactElement)) list) =
        let marksObj =
            createObj [
                for k, (color, label) in values ->
                    k.ToString(), createObj [
                        "style", createObj [ "color", color ]
                        "label", label
                    ]
            ]
        Interop.mkSliderProp "marks" marksObj

[<Erase>]
type sliderStyle =
    static member inline tracks (tracksProps: ISliderTrackProp seq) =
        Interop.mkStyleProp "tracks" (createObj !!tracksProps)
    static member inline track (trackProps: ISliderTrackProp seq) =
        Interop.mkStyleProp "track" (createObj !!trackProps)

[<Erase>]
type sliderTrack =
    static member inline color (color: string) =
        Interop.mkSliderTrackProp "color" color
    static member inline background (color: string) =
        Interop.mkSliderTrackProp "background" color
    static member inline height (height: int) =
        Interop.mkSliderTrackProp "height" height
    static member inline borderRadius (radius: int) =
        Interop.mkSliderTrackProp "borderRadius" radius

[<Erase>]
type dotStyle =
    static member inline color (color: string) =
        Interop.mkDotStyleProp "color" color
    static member inline background (color: string) =
        Interop.mkDotStyleProp "background" color
    static member inline height (height: int) =
        Interop.mkDotStyleProp "height" height
    static member inline width (width: int) =
        Interop.mkDotStyleProp "width" width
    static member inline borderRadius (radius: int) =
        Interop.mkDotStyleProp "borderRadius" radius
    static member inline borderColor (color: string) =
        Interop.mkDotStyleProp "borderColor" color
