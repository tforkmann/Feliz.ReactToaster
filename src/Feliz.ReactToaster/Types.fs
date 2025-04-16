namespace Feliz.ReactToaster

open Fable.Core

type IToastProp =
    interface
    end
type IToastContainerProp =
    interface
    end

type ITransition =
    interface
    end
[<StringEnum;RequireQualifiedAccess>]
type Position =
    | TopRight
    | TopLeft
    | BottomRight
    | BottomLeft
    | TopCenter
    | BottomCenter

[<StringEnum;RequireQualifiedAccess>]
type Theme =
    | Light
    | Dark
    | Colored

