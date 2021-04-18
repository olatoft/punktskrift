open System


module Result =
    let prepend firstResult restResult =
        match firstResult, restResult with
        | Ok first, Ok rest -> Ok (first :: rest)
        | Error err1, Ok _ -> Error err1
        | Ok _, Error err2 -> Error err2
        | Error err1, Error _ -> Error err1

    let sequence listOfResults =
        let initialValue = Ok []
        List.foldBack prepend listOfResults initialValue


let brailleCharacterToLatinCharacter brailleCharacter : Result<string, string> =
    match brailleCharacter with
    | 0b00000001uy -> Ok "a"
    | 0b00000011uy -> Ok "b"
    | _ -> Error "Ugyldig punktbokstav"


[<EntryPoint>]
let main _ =
    let a = 0b00000001uy
    let b = 0b00000011uy
    let brailleCharacters = [a; b; b; a]

    let letters =
        brailleCharacters
        |> List.map brailleCharacterToLatinCharacter
        |> Result.sequence
        |> Result.map (List.reduce (fun a b -> a + b))

    match letters with
    | Ok value -> printfn "%s" value
    | Error err -> printfn "Error: %s" err

    0
