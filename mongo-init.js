db.freezers.drop();
db.freezers.insert({ name: 'garage', drawers: [
        {
            name: 'drawer one',
            items: [
                {name: 'vlezeke', since: '2019-07-20', isVacuum: true, _id: ObjectId() },
                {name: 'kippeke', since: '2019-10-20', isVacuum: true, _id: ObjectId()},
                {name: 'viske', since: '2020-06-21', isVacuum: true, _id: ObjectId() },
            ], _id: ObjectId()
        },
        {
            name: 'drawer two', _id: ObjectId()
        },
        {
            name: 'drawer three', _id: ObjectId()
        },
        {
            name: 'drawer four', _id: ObjectId()
        },
        {
            name: 'drawer five', _id: ObjectId()
        },
        {
            name: 'drawer six', _id: ObjectId()
        },
        {
            name: 'drawer seven', _id: ObjectId()
        }]
    });
db.freezers.insert({ name: 'keuken', drawers: [ 
        {
            _id: ObjectId(),
            name: 'drawer one',
            items: [
                {name: 'croissants', since: '2019-01-20', isVacuum: false, _id: ObjectId() },
                {name: 'pizzadeeg', since: '2020-01-20', isVacuum: true, _id: ObjectId() },
            ]
        },
        {
            name: 'drawer two'
        }]
});