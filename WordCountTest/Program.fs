open System.IO

let readFile = File.ReadAllText(@"PATH TO TEXT")

let splitWords (string: string) =
  string.Split([|','; '.'; ' '|])
  |> Array.map (fun s -> s.Trim())
  |> Array.filter(fun x -> not(x.Equals("")))

let count words =
  words
  |> Seq.groupBy id
  |> Seq.map (fun (w, ws) -> (w, Seq.length ws))
  |> Seq.sortBy (snd >> (~-))
  |> Seq.toList