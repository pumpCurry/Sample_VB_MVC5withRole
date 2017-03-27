Public Class TransferDemoController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function Act1(ByVal id As Integer?, ByVal Message1 As String, ByVal Message2 As String, ByVal Message3 As String, ByVal Message4 As String) As ActionResult

        Dim controllerName = RouteData.Values("controller").ToString()
        Dim actionName = RouteData.Values("action").ToString()

        ViewData("Message0") = "Now Act2."
        ViewData("Message1") = "Came to Act1."
        ViewData("Message2") = Message2
        ViewData("Message3") = Message3
        ViewData("Message4") = Message4
        ViewData("Controller") = controllerName
        ViewData("Action") = actionName
        ViewData("ID") = id

        'Transfer to Act2
        Return TransferToAction("act2", "TransferDemo", New With {.id = id, .Message1 = ViewData("Message1"), .Message3 = ViewData("Message3")})

    End Function

    <TransferActionOnly>
    Function Act2(ByVal id As Integer?, ByVal Message1 As String, ByVal Message2 As String, ByVal Message3 As String, ByVal Message4 As String) As ActionResult

        Dim controllerName = RouteData.Values("controller").ToString()
        Dim actionName = RouteData.Values("action").ToString()

        ViewData("Message0") = "Now Act2."
        ViewData("Message1") = Message1
        ViewData("Message2") = "Came to Act2."
        ViewData("Message3") = Message3
        ViewData("Message4") = Message4
        ViewData("Controller") = controllerName
        ViewData("Action") = actionName
        ViewData("ID") = id

        'Render to Act2(This)
        Return View()

    End Function

    Function Act3(ByVal id As Integer?, ByVal Message1 As String, ByVal Message2 As String, ByVal Message3 As String, ByVal Message4 As String) As ActionResult

        Dim controllerName = RouteData.Values("controller").ToString()
        Dim actionName = RouteData.Values("action").ToString()

        ViewData("Message0") = "Now Act3."
        ViewData("Message1") = Message1
        ViewData("Message2") = Message2
        ViewData("Message3") = "Came to Act3."
        ViewData("Message4") = Message4
        ViewData("Controller") = controllerName
        ViewData("Action") = actionName
        ViewData("ID") = id

        'Transfer to Act1
        Return TransferToAction("act1", "TransferDemo", New With {.id = id, .Message3 = ViewData("Message3")})

    End Function

    Function Act4(ByVal id As Integer?, ByVal Message1 As String, ByVal Message2 As String, ByVal Message3 As String, ByVal Message4 As String) As ActionResult

        Dim controllerName = RouteData.Values("controller").ToString()
        Dim actionName = RouteData.Values("action").ToString()

        ViewData("Message0") = "Now Act4."
        ViewData("Message1") = Message1
        ViewData("Message2") = Message2
        ViewData("Message3") = Message3
        ViewData("Message4") = "Came to Act4."
        ViewData("Controller") = controllerName
        ViewData("Action") = actionName
        ViewData("ID") = id

        'Render to Act4(This)
        Return View()

    End Function

End Class
