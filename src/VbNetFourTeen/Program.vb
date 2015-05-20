Module Program

    Sub Main()
        Dim test As New Test("lalal")
        Console.WriteLine(test)
        Console.ReadLine()
    End Sub

End Module

Public Class Test

    Public Sub New(ByVal initialName As String)
        Name = initialName
        Length = If(Name?.Length, 0) 'Null Conditional Operator
        NameOfParameter = NameOf(initialName)
    End Sub

    Public ReadOnly Property Name As String 'Private Auto Properties
    Public ReadOnly Property Length As Integer
    Public ReadOnly Property NameOfParameter As String
    Public Property Collection As IEnumerable(Of String) = New List(Of String) From {"One", "Two"} 'Initializers For Auto Properties

    Public Overrides Function ToString() As String
        Return $"Name: {Name} - Set By: {NameOfParameter} - Length: {Length}" 'String Interpolation
    End Function

End Class
