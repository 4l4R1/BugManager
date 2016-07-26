Option Strict On
Option Explicit On

Imports System.IO

Module htmlClasses
    Friend Class Statistics
        Private _html As New System.Text.StringBuilder
        Private _title As String
        Private alt As Boolean
        Private count As Integer
        Private RowMode As Integer

        Friend Sub New(content As XElement)
            RowMode = 1
            _title = content.@title
            If String.IsNullOrEmpty(_title) Then _title = String.Empty
            Parse(content)
        End Sub

        Friend Sub New(title As String, content As XElement)
            RowMode = 0
            _title = title
            Parse(content)
        End Sub

        Friend Sub Parse(content As XElement)
            _html.Append("<!--StartFragment -->")

            _html.Append(<span style='font-size: 20px; color: #003080; vertical-align: bottom'><%= _title %></span>.ToString)

            If content.Elements.Any Then
                _html.Append(System.Environment.NewLine)

                '_html.Append(Space(2))
                _html.Append("<table>")
                '_html.Append(System.Environment.NewLine)

                '_html.Append(Space(4))
                _html.Append("<tbody>")
                _html.Append(System.Environment.NewLine)
                '_html.Append(System.Environment.NewLine)

                Header()

                For Each el As XElement In content.Elements
                    Row(el)
                Next

                '_html.Append(Space(4))
                _html.Append("</tbody>")

                '_html.Append(System.Environment.NewLine)
                '_html.Append(Space(2))
                _html.Append("</table>")
                '_html.Append(System.Environment.NewLine)
                _html.Append("<!--EndFragment -->")
            End If
        End Sub

        Friend Function page() As String
            Return My.Resources.htmlTemplate.Replace("%title%", _title).Replace("%content%", _html.ToString)
        End Function

        Private Sub Header()
            _html.Append("<tr style='background-color:#F8F8F8;'>")
            _html.Append("<td style='font-size: 14px;'></td>")
            _html.Append("<td style='font-size: 14px; vertical-align: bottom;'>Aeg</td>")
            If RowMode = 1 Then _html.Append("<td style='font-size: 14px; vertical-align: bottom;'>Nimi</td>")
            _html.Append("<td style='font-size: 14px; vertical-align: bottom;'>Saade</td>")
            _html.Append("<td style='font-size: 14px; vertical-align: bottom;'>Ajastus</td>")
        End Sub

        Private Sub Row(content As XElement)
            _html.Append(Space(5))
            If alt Then
                _html.Append("<tr style='background-color:#F0F0F0;'>")
            Else
                _html.Append("<tr style='background-color:#E0E0E0;'>")
            End If
            alt = Not alt
            count += 1
            '_html.Append(System.Environment.NewLine)

            '_html.Append(Space(6))
            _html.Append(<td style='font-size: 14px; vertical-align: bottom; text-align: right;'><%= String.Format("{0}.", count) %></td>.ToString)
            '_html.Append(System.Environment.NewLine)

            '_html.Append(Space(6))

            '_html.Append(<td style='font-size: 14px; vertical-align: bottom;'><%= content.@time %></td>.ToString)
            _html.Append(<td style='font-size: 14px; vertical-align: bottom;'><%= Date.Parse(content.@time).ToString("dd.MM.yy HH:mm:ss") %></td>.ToString)
            '_html.Append(System.Environment.NewLine)

            If RowMode = 1 Then
                '_html.Append(Space(6))
                _html.Append(<td style='font-weight: bold; font-size: 14px; vertical-align: bottom;'><%= content.@id %></td>.ToString)
                '_html.Append(System.Environment.NewLine)
            End If

            '_html.Append(Space(6))
            _html.Append(<td style='font-weight: bold; font-size: 14px; vertical-align: bottom;'><%= content.@title %></td>.ToString)
            '_html.Append(System.Environment.NewLine)

            '_html.Append(Space(6))

            Dim src As String = content.@src
            If String.IsNullOrEmpty(src) Then
                _html.Append(<td style='font-size: 14px; vertical-align: bottom;'><%= SlotDescription(content.@slot) %></td>.ToString)
            Else
                _html.Append(<td style='font-size: 14px; vertical-align: bottom;'><%= src %></td>.ToString)
            End If

            '_html.Append(System.Environment.NewLine)

            '_html.Append(Space(5))
            _html.Append("</tr>")
            '_html.Append(System.Environment.NewLine)
            _html.Append(System.Environment.NewLine)
        End Sub

        Private Function SlotDescription(id As String) As String
            Select Case Integer.Parse(id)
                Case 1 : Return "Käsitsi"
                Case 3 : Return "Saate algus"
                Case 9 : Return "Saate lõpp"
                Case 30 : Return "Saatekava"
                Case 31 : Return "Etteantud kellaaeg"
                Case 400 To 499 : Return Position(id, "Enne {0}. reklaami")
                Case 500 To 599
                    Dim pos As Integer = Integer.Parse(id.Substring(1, 1)) - 1
                    Return String.Format("Peale {0}. reklaami", pos)
                Case 600 To 699 : Return Position(id, "{0}. saateosa algus")
                Case 700 To 799 : Return Position(id, "{0}. saateosa ajal")
                Case 800 To 899 : Return Position(id, "{0}. saateosa lõpp")
                Case 1000 To 1099 : Return "Erilahendus"
                Case Else : Return String.Empty
            End Select
        End Function

        Private Function Position(id As String, template As String) As String
            Return String.Format(template, id.Substring(1, 1))
        End Function
    End Class


End Module
