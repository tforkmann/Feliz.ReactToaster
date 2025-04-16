# Feliz Binding for [ReactToastify](https://github.com/fkhadra/react-toastify/tree/main)

[![Feliz.ReactToaster on Nuget](https://buildstats.info/nuget/Feliz.ReactToaster)](https://www.nuget.org/packages/Feliz.ReactToaster/)
[![Docs](https://github.com/tforkmann/Feliz.ReactToaster/actions/workflows/Docs.yml/badge.svg)](https://github.com/tforkmann/Feliz.ReactToaster/actions/workflows/Docs.yml)

## Installation
Install the nuget package
```
dotnet paket add Feliz.ReactToaster
```

and install the npm package

```
npm install --save react-toastify
```

or use Femto:
```
femto install Feliz.ReactToaster
```

## Start test app

- Start your test app by cloning this repository and then execute:
```
dotnet run
```

## Example ReactToaster


Configure the toast container in your app:
```fs
    let toast message =
        ToastApi.message message [
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

    let errorToast title : Cmd<_> = toast title |> ToastApi.errorToast
```
Use the toast with Elmish:
```fs
    type Msg =
        | ShowToast
        ....
    let init () =
        let model = { ... }
        let cmd = Cmd.none
        model, cmd
    let update msg model =
        match msg with
        | ShowToast -> model, errorToast "Toast shown!"
        | _ -> model, Cmd.none
```
In your app, add the toast container:
```fs
    let view model dispatch =
        Html.div [
            Html.button [
                prop.text "Show Toast"
                prop.onClick (fun _ -> dispatch ShowToast)
            ]
            ReactToaster.toastContainer []
        ]
```

You can find more examples [here](https://tforkmann.github.io/Feliz.ReactToaster/)
