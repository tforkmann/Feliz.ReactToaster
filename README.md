# Feliz Binding for [ReactToastify](https://github.com/fkhadra/react-toastify/tree/main)

[![Feliz.ReactToaster on Nuget](https://buildstats.info/nuget/Feliz.ReactToaster)](https://www.nuget.org/packages/Feliz.ReactToaster/)
[![Docs](https://github.com/tforkmann/Feliz.ReactToaster/actions/workflows/Docs.yml/badge.svg)](https://github.com/tforkmann/Feliz.ReactToaster/actions/workflows/Docs.yml)

Wrapper for [react-toastify](https://www.npmjs.com/package/react-toastify) v11.x - Beautiful notifications for your F#/Fable React applications.

## Installation

Install the nuget package:
```bash
dotnet paket add Feliz.ReactToaster
```

and install the npm package:
```bash
npm install --save react-toastify
```

or use Femto:
```bash
femto install Feliz.ReactToaster
```

## Start test app

Start your test app by cloning this repository and then execute:
```bash
dotnet run
```

## Basic Usage

### 1. Add the ToastContainer to your app

```fsharp
open Feliz.ReactToaster

let view model dispatch =
    Html.div [
        Html.button [
            prop.text "Show Toast"
            prop.onClick (fun _ -> dispatch ShowToast)
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
```

### 2. Trigger toasts directly

```fsharp
open Feliz.ReactToaster

// Simple string toasts
ToastApi.successString "Operation completed!" []
ToastApi.errorString "Something went wrong!" []
ToastApi.infoString "Here's some info" []
ToastApi.warningString "Be careful!" []

// With custom options
ToastApi.successString "Saved!" [
    toast.position Position.BottomRight
    toast.autoClose 3000
    toast.theme Theme.Dark
]
```

### 3. Use with Elmish

```fsharp
open Feliz.ReactToaster
open Elmish

let toast title message =
    ToastApi.message title message [
        toast.position Position.TopRight
        toast.autoClose 5000
        toast.hideProgressBar false
        toast.closeOnClick true
        toast.pauseOnHover true
        toast.draggable true
        toast.theme Theme.Light
        toast.transition TransitionToast.flip
    ]

let errorToast title message : Cmd<_> = toast title message |> ToastApi.errorToast
let successToast title message : Cmd<_> = toast title message |> ToastApi.successToast

type Msg =
    | ShowToast
    | SaveComplete

let update msg model =
    match msg with
    | ShowToast -> model, errorToast "Error" "Something went wrong!"
    | SaveComplete -> model, successToast "Success" "Data saved successfully!"
```

## Advanced Features

### Loading Toasts

```fsharp
// Show a loading toast
let toastId = ToastApi.loadingString "Loading data..." []

// Later, update it to success or error
ToastApi.updateWithString toastId "Data loaded!" [
    toast.toastType ToastType.Success
    toast.isLoading false
]
```

### Promise-based Toasts

```fsharp
let fetchData () =
    promise {
        // async operation
        return! someAsyncCall()
    }

ToastApi.promise
    fetchData
    { Pending = "Loading..."; Success = "Done!"; Error = "Failed!" }
    []
```

### Toast Control

```fsharp
// Dismiss all toasts
ToastApi.dismiss ()

// Dismiss specific toast
ToastApi.dismissById "my-toast-id"

// Check if toast is active
if ToastApi.isActive "my-toast-id" then
    // do something

// Pause/Play toasts
ToastApi.pause ()
ToastApi.play ()
```

### Stacked Toasts (v11 feature)

```fsharp
ReactToaster.toastContainer [
    toastContainer.stacked true
    toastContainer.position Position.TopRight
]
```

## ToastContainer Props

| Prop | Type | Description |
|------|------|-------------|
| `position` | `Position` | Toast position (TopRight, TopLeft, TopCenter, BottomRight, BottomLeft, BottomCenter) |
| `autoClose` | `int` or `bool` | Auto-close delay in ms, or `false` to disable |
| `hideProgressBar` | `bool` | Hide the progress bar |
| `closeOnClick` | `bool` | Close toast on click |
| `pauseOnHover` | `bool` | Pause timer on hover |
| `pauseOnFocusLoss` | `bool` | Pause when window loses focus |
| `draggable` | `bool` | Allow drag to dismiss |
| `draggablePercent` | `int` | Drag threshold percentage |
| `draggableDirection` | `DraggableDirection` | X or Y axis |
| `theme` | `Theme` | Light, Dark, or Colored |
| `transition` | `obj` | Bounce, Slide, Zoom, or Flip |
| `newestOnTop` | `bool` | Show newest toasts on top |
| `rtl` | `bool` | Right-to-left support |
| `limit` | `int` | Maximum number of toasts |
| `stacked` | `bool` | Enable stacked mode (v11) |
| `containerId` | `string` or `int` | Container identifier |
| `className` | `string` | CSS class name |
| `toastClassName` | `string` | CSS class for toasts |
| `bodyClassName` | `string` | CSS class for toast body |
| `progressClassName` | `string` | CSS class for progress bar |
| `closeButton` | `bool` or `ReactElement` | Custom close button |
| `icon` | `bool` or `ReactElement` | Custom icon |
| `role` | `string` | ARIA role |

## Toast Options

| Option | Type | Description |
|--------|------|-------------|
| `toastId` | `string` or `int` | Unique toast identifier |
| `toastType` | `ToastType` | Info, Success, Warning, Error, Default |
| `position` | `Position` | Override container position |
| `autoClose` | `int` or `bool` | Override auto-close |
| `delay` | `int` | Delay before showing |
| `className` | `string` | CSS class |
| `style` | `obj` | Inline styles |
| `icon` | `bool`, `string`, or `ReactElement` | Custom icon |
| `theme` | `Theme` | Override theme |
| `onClick` | `unit -> unit` | Click handler |
| `onOpen` | `unit -> unit` | Open callback |
| `onClose` | `unit -> unit` | Close callback |
| `isLoading` | `bool` | Show loading state |
| `data` | `obj` | Custom data |

## ToastApi Methods

| Method | Description |
|--------|-------------|
| `success`, `error`, `info`, `warning`, `warn`, `defaultT` | Show toast with title and message |
| `successString`, `errorString`, `infoString`, etc. | Show toast with string only |
| `successSimple`, `errorSimple`, etc. | Show toast with ReactElement |
| `loading`, `loadingString`, `loadingSimple` | Show loading toast |
| `dismiss`, `dismissById` | Dismiss toasts |
| `update`, `updateWithString`, `updateWithContent` | Update existing toast |
| `isActive` | Check if toast is displayed |
| `done` | Complete controlled progress |
| `play`, `playById`, `pause`, `pauseById` | Control timer |
| `promise` | Handle promise states |
| `clearWaitingQueue`, `clearWaitingQueueById` | Clear queue |

## Elmish Commands

| Command | Description |
|---------|-------------|
| `errorToast` | Show error toast |
| `successToast` | Show success toast |
| `infoToast` | Show info toast |
| `warningToast` | Show warning toast |
| `defaultToast` | Show default toast |
| `loadingToast` | Show loading toast |

You can find more examples [here](https://tforkmann.github.io/Feliz.ReactToaster/)
