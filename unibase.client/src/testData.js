const TestData = [{
    "key": '0',
    "teacherName": "teacherName",
    "GroupName": "GroupName}",
    "studentCount": 40,
    "discipline": "discipline}",
    "lectionHours": 32,
    "nagrCode": 30,
    "lectionType": "lectionType",
    "journal_id": 0
},
{
    "key": 1,
    "teacherName": "teacherName1",
    "GroupName": "GroupName1}",
    "studentCount": 45,
    "discipline": "discipline1}",
    "lectionHours": 35,
    "nagrCode": 35,
    "lectionType": "lectionType1",
    "journal_id": 1
    },
    
]
function generateData() {
    for (var i = 0; i < 120; i++) {
        TestData.push({
            "key": i,
            "teacherName": "teacherName",
            "GroupName": "GroupName}",
            "studentCount": 40,
            "discipline": "discipline}",
            "lectionHours": 32,
            "nagrCode": 30,
            "lectionType": "lectionType",
            "journal_id": 0
        })
    }
    return TestData
    
}
export default generateData