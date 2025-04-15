# Feliz Binding for [RC-Slider](https://github.com/react-component/slider)

[![Feliz.ReactToaster on Nuget](https://buildstats.info/nuget/Feliz.ReactToaster)](https://www.nuget.org/packages/Feliz.ReactToaster/)
[![Docs](https://github.com/tforkmann/Feliz.ReactToaster/actions/workflows/Docs.yml/badge.svg)](https://github.com/tforkmann/Feliz.ReactToaster/actions/workflows/Docs.yml)

## Installation
Install the nuget package
```
dotnet paket add Feliz.ReactToaster
```

and install the npm package

```
npm install --save rc-slider
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

```fs
Here is an example ReactToaster
```fs
    ReactToaster.slider [
        slider.min 20
        slider.defaultValue 20
        slider.stepNull
        slider.marksWithStyle [
            20, ("red", Html.text "20")
            40, ("blue", Html.text "40")
            100, ("green", Html.text "100")
        ]
    ]

```

You can find more examples [here](https://tforkmann.github.io/Feliz.ReactToaster/)
