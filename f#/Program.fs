open System
open System.IO.Ports


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

    // while true do
    //     Async.Sleep 100 |> Async.RunSynchronously
    //     let mutable text = ""

    //     while Console.KeyAvailable do
    //         let value =
    //             Console.ReadKey true
    //             |> (fun c -> c.Key.ToString ())
    //             // |> printfn "%A"

    //         text <- text + value

    //     printfn "%A" text


    // while not Console.KeyAvailable do
    //     Async.Sleep 10000
    //     |> ignore
    
    // Console.ReadKey ()
    // |> (fun c -> c.Key)
    // |> printfn "%A"

    let port = new SerialPort("/dev/ttyUSB0", 9600)
    port.Open ()
    
    port.ReadByte ()
    |> printfn "%A"
    
    0
