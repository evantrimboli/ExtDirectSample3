Ext.Direct.addProvider(Sample.Remote.TreeHandler);
Ext.onReady(function(){
   var tree = new Ext.tree.TreePanel({
       renderTo: 'container',
       width: 400,
       height: 600,
       title: 'Tree - Cities',
       enableDD: true,
       selModel: new Ext.tree.DefaultSelectionModel({
           listeners: {
               selectionchange: function(sm, node){
                   var tb = tree.getTopToolbar(),
                       add = true,
                       remove = true;
                       
                   if(node){
                       add = false;
                       remove = node == tree.getRootNode();
                   }
                   tb.getComponent('add').setDisabled(add);
                   tb.getComponent('remove').setDisabled(remove);
                   
               }
           }
       }),
       tbar: [{
           iconCls: 'icon-add',
           itemId: 'add',
           text: 'Add',
           disabled: true,
           handler: function(){
               var node = tree.getSelectionModel().getSelectedNode();
               node.expand(false, true, function(){
                   var newNode = node.appendChild({
                       text: 'New Node'
                   });
                   newNode.isNew = true;
                   ed.triggerEdit(newNode);
               });
           }
       },{
           iconCls: 'icon-remove',
           itemId: 'remove',
           text: 'Remove',
           disabled: true,
           handler: function(){
               var node = tree.getSelectionModel().getSelectedNode();
               node.remove(true);
               Sample.Tree.Remove(node.id);
           }
       }, '->', {
           iconCls: 'icon-load',
           text: 'Reload tree data to initial state',
           handler: function(){
               var root = tree.getRootNode();
               root.collapse();
               root.loaded = false;
               
               Sample.Tree.Reset();
           }
       }],
       loader: new Ext.tree.TreeLoader({
            directFn: Sample.Tree.Load
        }),
       root: {
           id: 'root',
           text: 'Root'
       },
       listeners: {
           movenode : function(t, node, oldParent, newParent, idx){
               Sample.Tree.Move(node.id, newParent.id, idx);
           }
       }
   });
   
   var ed = new Ext.tree.TreeEditor(tree, {
      xtype: 'textfield',
      allowBlank: false
   }, {
       ignoreNoChange: false,
       listeners: {
           complete: function(ed, value, oldValue){
               var node = ed.editNode;
               if(node.isNew){
                   Sample.Tree.Add(node.parentNode.id, value, function(data){
                       node.isNew = false;
                       node.setId(id);
                   });
               }else if(value != oldValue){
                   Sample.Tree.SetName(node.id, value);
               }
           }
       }
   });
});