import QtQuick 2.9
import QtQuick.Layouts 1.3
import QtQuick.Controls 1.4
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Dialogs 1.3
import QtQuick.Controls.Styles 1.4


// right place holder
ScrollView {

    property var views : {'pth': pthView, 'smd' : smdView}
    id: rightPane
    leftPadding: 10
    topPadding: 10
    ScrollBar.horizontal.policy: ScrollBar.AsNeeded
    ScrollBar.vertical.policy: ScrollBar.AsNeeded
    contentWidth: writeContent.implicitWidth
    contentHeight: writeContent.implicitHeight

    Column {
        id: writeContent
        visible: true
        Label {
            padding: 10
            text: qsTr("PTH")
            font.weight: Font.Bold
            font.pointSize : 14
        }
        Repeater {
            id: pthView
            Row {

                Column {

                    Label {
                        padding: 10
                        width: 120
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.code
                    }
                }
                Column {

                    Label {
                        padding: 10
                        width: 80
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.type
                    }
                }
                Column {

                    Label {
                        padding: 10
                        width: 240
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.description
                    }
                }
                Column {

                    Label {
                        padding: 10
                        width: 160
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.value
                    }
                }

                Column {
                    Label {
                        padding: 10
                        width: 250
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.reference
                    }
                }
            }
        }
        Label {
            padding: 10
            text: qsTr("SMD")
            font.weight: Font.Bold
            font.pointSize : 14
        }
        Repeater {
            id: smdView
            Row {

                Column {

                    Label {
                        padding: 10
                        width: 120
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.code
                    }
                }
                Column {

                    Label {
                        padding: 10
                        width: 80
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.type
                    }
                }
                Column {

                    Label {
                        padding: 10
                        width: 240
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.description
                    }
                }
                Column {

                    Label {
                        padding: 10
                        width: 160
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.value
                    }
                }

                Column {
                    Label {
                        padding: 10
                        width: 250
                        background: Rectangle {
                            color: '#2C313A'
                            border.color: "gray"
                            border.width: 1
                        }
                        text: modelData.reference
                    }
                }
            }
        }
    }
    background: Rectangle {
        color: '#2C313A'
        width: rightPane.width
    }
}
        // modify splitter style
