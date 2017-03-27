'=======================================================
'
'=======================================================

Public Module ControllerContextExtensionsModule

    <System.Runtime.CompilerServices.Extension> _
    Public Function IsTransferAction(context As ControllerContext) As Boolean
        Dim routeData As RouteData = context.RouteData
        If routeData Is Nothing Then
            Return False
        End If

        Return context.HttpContext.Request.QueryString(TransferActionOnlyAttribute.IsTransferActionMarker) IsNot Nothing
    End Function

End Module

'=======================================================

Public Module TransferToRouteResultModule
    Public Class TransferToRouteResult
        Inherits ActionResult

        Private m_ActionName As String
        Private m_ControllerName As String
        Private m_RouteValues As RouteValueDictionary

        Public Sub New(actionName As String, controllerName As String, routeValues As Object)
            Me.New(actionName, controllerName, If(routeValues Is Nothing, Nothing, New RouteValueDictionary(routeValues)))
        End Sub

        Public Sub New(actionName As String, controllerName As String, routeValues As RouteValueDictionary)
            m_ActionName = actionName
            m_ControllerName = controllerName
            m_RouteValues = If(routeValues Is Nothing, New RouteValueDictionary(), New RouteValueDictionary(routeValues))
        End Sub

        ''' <summary>
        ''' Gets or sets the name of the action to use for generating the URL.
        ''' </summary>
        Public Property ActionName() As String
            Get
                Return m_ActionName
            End Get
            Set(value As String)
                m_ActionName = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the name of the controller to use for generating the URL.
        ''' </summary>
        Public Property ControllerName() As String
            Get
                Return m_ControllerName
            End Get
            Set(value As String)
                m_ControllerName = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the route data to use for generating the URL.
        ''' </summary>
        Public Property RouteValues() As RouteValueDictionary
            Get
                Return m_RouteValues
            End Get
            Set(value As RouteValueDictionary)
                m_RouteValues = value
            End Set
        End Property

        Public Overrides Sub ExecuteResult(context As ControllerContext)
            If context Is Nothing Then
                Throw New ArgumentNullException("context")
            End If

            RouteValues.Add(TransferActionOnlyAttribute.IsTransferActionMarker, True)

            Dim urlHelper = New UrlHelper(context.RequestContext)
            Dim destinationUrl = urlHelper.Action(ActionName, ControllerName, RouteValues)
            If String.IsNullOrEmpty(destinationUrl) Then
                Throw New InvalidOperationException("NoRoutesMatched")
            End If

            context.HttpContext.Server.TransferRequest(destinationUrl, True)
        End Sub
    End Class
End Module

'=======================================================

Public Module ControllerExtentionModule

    ''' <summary>
    ''' Transfers to the specified action using the <paramref name="actionName"/>
    ''' and the <paramref name="controllerName"/>.
    ''' </summary>
    ''' <param name="actionName">The name of the action.</param>
    ''' <param name="controllerName">The name of the controller.</param>
    ''' <returns>The created <see cref="TransferToRouteResult"/> for the response.</returns>

    <NonAction> _
    <System.Runtime.CompilerServices.Extension> _
    Public Function TransferToAction(controller As Controller, actionName As String, controllerName As String) As TransferToRouteResult
        Return TransferToAction(controller, actionName, controllerName, routeValues:=Nothing)
    End Function

    ''' <summary>
    ''' Transfers to the specified action using the specified <paramref name="actionName"/>,
    ''' <paramref name="controllerName"/>, and <paramref name="routeValues"/>.
    ''' </summary>
    ''' <param name="actionName">The name of the action.</param>
    ''' <param name="controllerName">The name of the controller.</param>
    ''' <param name="routeValues">The parameters for a route.</param>
    ''' <returns>The created <see cref="TransferToRouteResult"/> for the response.</returns>
    <NonAction> _
    <System.Runtime.CompilerServices.Extension> _
    Public Function TransferToAction(controller As Controller, actionName As String, controllerName As String, routeValues As Object) As TransferToRouteResult
        Return New TransferToRouteResult(actionName, controllerName, routeValues)
    End Function
End Module

'=======================================================
Public Module TransferActionOnlyAttributeModule
    ''' <summary>Represents an attribute that is used to indicate that an action method should be called only from a TransferToAction.</summary>
    <AttributeUsage(AttributeTargets.[Class] Or AttributeTargets.Method, AllowMultiple:=False, Inherited:=True)> _
    Public NotInheritable Class TransferActionOnlyAttribute
        Inherits FilterAttribute
        Implements IAuthorizationFilter

        Public Const IsTransferActionMarker As String = "IsTransferAction"

        ''' <summary>Called when authorization is required.</summary>
        ''' <param name="filterContext">An object that encapsulates the information that is required in order to authorize access to the transfer action.</param>
        Public Sub OnAuthorization(filterContext As AuthorizationContext) Implements IAuthorizationFilter.OnAuthorization
            If filterContext Is Nothing Then
                Throw New ArgumentNullException("filterContext")
            End If

            If Not filterContext.IsTransferAction() Then
                Throw New InvalidOperationException(String.Format("The action '{0}' is accessible only by a transfer request.", filterContext.ActionDescriptor.ActionName))
            End If
        End Sub

    End Class
End Module
'=======================================================

