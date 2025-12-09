module Docs.Router

open Browser.Types
open Feliz.Router
open Fable.Core.JsInterop

type Page =
    | Install
    | Use
    | Examples
    | Advanced

[<RequireQualifiedAccess>]
module Page =
    let defaultPage = Install

    let parseFromUrlSegments =
        function
        | [ "use" ] -> Use
        | [ "examples" ] -> Examples
        | [ "advanced" ] -> Advanced
        | [] -> Install
        | _ -> defaultPage

    let noQueryString segments : string list * (string * string) list = segments, []

    let toUrlSegments =
        function
        | Install -> [] |> noQueryString
        | Examples -> [ "examples" ] |> noQueryString
        | Advanced -> [ "advanced" ] |> noQueryString
        | Use -> [ "use" ] |> noQueryString

[<RequireQualifiedAccess>]
module Router =
    let goToUrl (e: MouseEvent) =
        e.preventDefault ()
        let href: string = !!e.currentTarget?attributes?href?value
        Router.navigate href

    let navigatePage (p: Page) =
        p |> Page.toUrlSegments |> Router.navigate

[<RequireQualifiedAccess>]
module Cmd =
    let navigatePage (p: Page) = p |> Page.toUrlSegments |> Cmd.navigate
