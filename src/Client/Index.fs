module Client

open Feliz
open Feliz.Router
open Fable.Core.JsInterop
open Thoth.Json
open Shared.Types

open Browser

let init () =
  let model =
    match Decode.Auto.fromString<Model> window?__INIT_STATE__ with
    | Ok model -> model
    | Error er ->
        console.error("Cannot decode init state", er, window?__INIT_STATE__)
        Model.Empty
  model

let model = init()

ReactDOM.render(
    Client.HSCode.Router(),
    document.getElementById "feliz-app"
)