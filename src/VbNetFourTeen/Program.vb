Imports System.Math
Imports System.Runtime.CompilerServices

Module Program

    Sub Main()
        Dim test As New Test("lalal")
        Console.WriteLine(test)
        Console.ReadLine()

        Console.WriteLine(test.DivideLength(0))
        Console.ReadLine()

        Console.WriteLine(test.IsString(42))
        Console.ReadLine()

        Console.WriteLine(New Badcollection From {"one", "two", "three"}) 'Collection Initializers with Extension 'Add'
        Console.ReadLine()
    End Sub

    <Extension>
    Public Sub Add(list As Badcollection, value As String)
        list.BadAdd(value)
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
        Return $"Name: {Name} - Set By: {NameOfParameter} - Length: {Length}
            Whoo! Newline" 'String Interpolation & Newline in strings
    End Function

    Public Function DivideLength(ByVal by As Double)
        Try
            Return Round(Length / by)
        Catch ex As DivideByZeroException When (ex.Message.Length > 0) 'Exception Filters
            Return 0
        End Try
    End Function

    Public Function IsString(ByVal obj As Object)
        If TypeOf obj IsNot String Then 'TypeOf IsNot
            Return False
        Else
            Return True
        End If
    End Function
End Class

Public Class Badcollection
    Implements IEnumerable(Of String)

    Private _internalCollection As New List(Of String)

    Public Sub BadAdd(value As String)
        _internalCollection.Add(value)
    End Sub

    Public Overrides Function ToString() As String
        Return String.Join(",", _internalCollection)
    End Function

    Public Function GetEnumerator() As IEnumerator(Of String) Implements IEnumerable(Of String).GetEnumerator
        Return _internalCollection.GetEnumerator()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return _internalCollection.GetEnumerator()
    End Function
End Class
