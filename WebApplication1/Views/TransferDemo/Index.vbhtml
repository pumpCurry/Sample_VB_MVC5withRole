@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>TransferToAction<br />for ASP.NET MVC 5<small> [VB.net Version]</small></h1>
    <p class="lead">Converted C# to VB.NET, Base Technorogy from: <a href="https://blogs.msdn.microsoft.com/riwickel/2016/03/29/transfertoaction-for-asp-net-mvc-5/" target="_blank">https://blogs.msdn.microsoft.com/</a></p>
</div>

<div>
    <ul>
        <li>@(Html.ActionLink(linkText:="[Act1] → TransferToAction to Act2.", _
                        controllerName:="TransferDemo", _
                            actionName:="Act1", _
                           routeValues:=New With {.id = 11111}, _
                        htmlAttributes:=Nothing _
            ))</li>
        <li>@(Html.ActionLink(linkText:="[Act2] → Cannot Access to Act2(Add Tagging <TransferActionOnly>).", _
                        controllerName:="TransferDemo", _
                            actionName:="Act2", _
                           routeValues:=New With {.id = 22222}, _
                        htmlAttributes:=Nothing _
            ))</li>
        <li>@(Html.ActionLink(linkText:="[Act3] → TransferToAction goes Twice. Act1→Act2", _
                        controllerName:="TransferDemo", _
                            actionName:="Act3", _
                           routeValues:=New With {.id = 33333}, _
                        htmlAttributes:=Nothing _
            ))</li>
        <li>@(Html.ActionLink(linkText:="[Act4] → No Use TransferToAction.", _
                        controllerName:="TransferDemo", _
                            actionName:="Act4", _
                           routeValues:=New With {.id = 44444}, _
                        htmlAttributes:=Nothing _
            ))</li>
    </ul>

</div>
