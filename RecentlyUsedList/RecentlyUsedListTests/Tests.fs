module Tests

open Program
open Xunit
open FsUnit.Xunit

module ``Given a newly created recently used list`` =

    [<Fact>]
    let ``then it should contain no items`` () =
        let sut = RecentlyUsedList(capacity = 3)

        //Assert.Equal<List<string>>([], sut.Items)
        sut.Items |> should equal List.empty<string>
        sut.Items |> should be Empty

module ``Given an empty recently used list`` =

    [<Fact>]
    let ``when you add an item then the list contains only that item`` () =
        let sut = RecentlyUsedList(capacity = 3)
        
        sut.Add("Item1")
        
        sut.Items |> should equal ["Item1"]

module ``Given a non-empty recently used list that is not at capacity`` =

    [<Fact>]
    let ``when you add an item not already in list then the item is added to the start of the list`` () =
        let sut = RecentlyUsedList(capacity = 3)
        sut.Add("Item1")

        sut.Add("Item2")
        
        sut.Items |> should equal ["Item2";"Item1"]

module ``Given an item is already in the list`` =

    [<Fact>]
    let ``when you add an item already in list then the item is moved to the start of the list`` () =
        let sut = RecentlyUsedList(capacity = 3)
        sut.Add("Item1")
        sut.Add("Item2")
        
        sut.Add("Item1")
        
        sut.Items |> should equal ["Item1";"Item2"]

module ``Given a recently used list that is at capacity`` =
    
    [<Fact>]
    let ``when you add an item not in the list then the new item is added and the oldest item is dropped from the list`` () =
        let sut = RecentlyUsedList(capacity = 3)
        sut.Add("Item1")
        sut.Add("Item2")
        sut.Add("Item3")

        sut.Add("Item4")

        sut.Items |> should equal ["Item4";"Item3";"Item2"]

module ``Given a recently used list that is at capacity and already contains the item`` =

    [<Fact>]
    let ``when you add an item already in the list then the item is moved to the start of the list`` () =
        let sut = RecentlyUsedList(capacity = 3)
        sut.Add("Item1")
        sut.Add("Item2")
        sut.Add("Item3")

        sut.Add("Item2")

        sut.Items |> should equal ["Item2";"Item3";"Item1"]