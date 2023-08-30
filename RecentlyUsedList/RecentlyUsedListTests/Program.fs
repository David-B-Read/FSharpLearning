module Program 

type RecentlyUsedList(capacity:int) =
    let items = ResizeArray<string>(capacity)
    let add item =
        item |> items.Remove |> ignore
        if items.Count = items.Capacity then items.RemoveAt 0
        items.Add item

    member _.Add(item:string) = add item
    member _.Items = items |> Seq.toList |> List.rev