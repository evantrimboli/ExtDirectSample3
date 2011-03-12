Ext.Direct.addProvider(Sample.Remote.TransformersHandler);
Ext.onReady(function(){

    var reader = new Ext.data.JsonReader({
        root: 'root',
        idProperty: 'name'
    }, ['name', 'image', {type: 'int', name: 'size'}]);
    
    var proxy = new Ext.data.DirectProxy({
        api: {
            read: Sample.Transformers.Load
        }
    });
    
    var store = new Ext.data.Store({
        reader: reader,
        proxy: proxy
    });
    
    /*
    Also could have created the store:
    var store = new Ext.data.DirectStore({
        directFn: Sample.Transformers.Load,
        root: 'root',
        idProperty: 'name',
        fields: ['name', 'image', {type: 'int', name: 'size'}]
    });
    */
    
    var tpl = new Ext.XTemplate(
        '<tpl for=".">',
            '<div class="thumb-wrap">',
		          '<div class="thumb"><img src="{image}" title="{name}"></div>',
		          '<span>{name} ({size:this.formatSize})</span>',
		      '</div>',
        '</tpl>',
        '<div class="x-clear"></div>'
    , {
        formatSize : function(v){
            var ext = ['B', 'kB', 'MB'],
                unitCount = 0;
               
            for(; v > 1024; unitCount++){
                v /= 1024;
            }
            return (Math.round(v * 100) / 100) + ' ' + ext[unitCount];

        }
    });
    
    new Ext.Panel({
        renderTo: 'container',
        title: 'More than meets the eye',
        width: 600,
        height: 600,
        layout: 'fit',
        tbar: [{
            iconCls: 'icon-load',
            text: 'Load',
            handler: function(){
                store.load();
            }
        }],
        items: {
            xtype: 'dataview',
            store: store,
            tpl: tpl,
            singleSelect: true,
            itemSelector: 'div.thumb-wrap',
            overClass: 'thumb-over',
            selectedClass: 'thumb-selected'
        }
    });

});