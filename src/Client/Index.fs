module Index

open Elmish
open Feliz
open Feliz.ReactToastify

type Model = { Txt: string }

type Msg = UpdateTxt of string

let init () = { Txt = "" }, Cmd.none

let update msg (model: Model) =
    match msg with
    | UpdateTxt txt -> { model with Txt = txt }, Cmd.none

// [<ReactComponent>]
// let Slider () =
//     ReactToastify.slider [
//         slider.min 20
//         slider.defaultValue 20
//         slider.stepNull
//         slider.marksWithStyle [
//             20, ("red", Html.text "20")
//             40, ("blue", Html.text "40")
//             100, ("green", Html.text "100")
//         ]
//         slider.styles [
//             sliderStyle.track [
//                 sliderTrack.background "red"
//             ]
//         ]
//         slider.onChange (fun value ->
//             Browser.Dom.console.log value
//         )
//         slider.dotStyle [
//             dotStyle.borderColor "orange"
//         ]
//         slider.activeDotStyle [
//             dotStyle.borderColor "yellow"
//         ]
//     ]
[<ReactComponent>]
let ReactRange () =
    ReactToastify.slider [
        slider.range
        slider.allowCross false
        slider.defaultValueRange (20, 80)
        slider.min 0
        slider.max 100
        slider.onChangeRange (fun (x,y) ->
            Browser.Dom.console.log (x, y)
        )
        // slider.min 20
        // slider.defaultValue 20
        // slider.stepNull
        // slider.marksWithStyle [
        //     20, ("red", Html.text "20")
        //     40, ("blue", Html.text "40")
        //     100, ("green", Html.text "100")
        // ]
        // slider.styles [
        //     sliderStyle.track [
        //         sliderTrack.background "red"
        //     ]
        // ]
        // slider.onChange (fun value ->
        //     Browser.Dom.console.log value
        // )
        // slider.dotStyle [
        //     dotStyle.borderColor "orange"
        // ]
        // slider.activeDotStyle [
        //     dotStyle.borderColor "yellow"
        // ]
    ]

let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        prop.style [ style.height 600; style.width 600; style.marginLeft 100 ]
        prop.children [
            Html.h1 "Hello from ReactToastify"
            ReactRange()
        ]

    ]
