# How to access a nested ListView from the parent DetailView's controller and vice versa

<i>Update: Approaches from this example are now described in the <a href="https://docs.devexpress.com/eXpressAppFramework/113161/task-based-help/views/how-to-access-master-detail-view-and-nested-list-view-environment">How to: Access Master Detail View and Nested List View Environment</a> topic. Refer to it for a more detailed description.</i>

<p>This example is based on the following facts:</p><br />
<p>1. The nested ListView is shown in the parent DetailView via the ListPropertyEditor. The ListPropertyEditor class has the Frame property that returns the nested frame and the ListView property that returns the nested ListView. To get the ListPropertyEditor, use the DetailView.FindItem or DetailView.GetItems method.</p><br />
<p>2. The nested list view's frame is represented by the NestedFrame class that has the ViewItem property, which returns the ListPropertyEditor from the parent DetailView. It is possible to access the parent DetailView via the ListPropertyEditor's View property.</p><br />
<p>Note that this code is required only if you need to access views and frames. If you need to access child business objects from the parent DetailView, simply get the DetailView's CurrentObject, cast it to the corresponding type and use its collection property. If you need to access the parent object from the nested ListView, use the PropertyCollectionSource.MasterObject property, as shown in the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3161"><u>How to: Access the Master Object from a Nested List View</u></a> help topic.</p>
<p><strong>See Also:</strong><br />
<a href="https://github.com/DevExpress-Examples/how-to-access-the-master-object-from-the-nested-list-view-e950">E950</a><br>
<a href="https://github.com/DevExpress-Examples/how-to-access-the-master-detailview-information-from-a-nested-listview-controller-e1012">E1012</a><br>
</p>
<br/>




