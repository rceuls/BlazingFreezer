db.freezers.drop();
db.freezers.insert({ name: 'garage', drawers: [
        {
            name: 'drawer one',
            items: [
                {name: 'vlezeke'},
                {name: 'kippeke'},
                {name: 'viske'},
            ]
        },
        {
            name: 'drawer two'
        },
        {
            name: 'drawer three'
        },
        {
            name: 'drawer four'
        },
        {
            name: 'drawer five'
        },
        {
            name: 'drawer six'
        },
        {
            name: 'drawer seven'
        }]
    });
db.freezers.insert({ name: 'keuken', drawers: [ 
        {
            name: 'drawer one',
            items: [
                {name: 'croissants'},
                {name: 'pizzadeeg'},
            ]
        },
        {
            name: 'drawer two'
        }]
});