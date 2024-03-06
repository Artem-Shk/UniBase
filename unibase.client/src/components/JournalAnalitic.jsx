﻿import styles from "./journal_analitic.module.css"
import "react-datepicker/dist/react-datepicker.css";
import React, { useEffect, useState } from 'react';
import DatePicker from "react-datepicker";
import { Chart as ChartJS, ArcElement, Tooltip } from 'chart.js';
import { Doughnut } from 'react-chartjs-2';
import Button from './Button'
import GoodRowWithData from './GoodRowWithData'
import MyDatePicker from './MyDatePicker'
import FindLine from './FindLine'
import Filter from './Filter'
//import generateData from 'C:/Users/Администратор/Source/Repos/Artem-Shk/UniBase/unibase.client/src/testData.js'

import Paginator from './Paginator'
ChartJS.register(ArcElement, Tooltip);
//const TestData = generateData();
export default function JournalAnalitic() {
    return (
        <ListOfJournals />
    )
}
function Body() {
    return (<div className={styles.main_container}>
                <ListOfJournals />
            </div>)
}
function LeftMenu() {
    return (
        <div> 
        </div>
    )
}
// тут пропсы у хедеров строк надо поменять а то хуйня а именно без {} сделать
function ListOfJournals() {
    const [journals, setJournals] = useState();
    const [click, ClickEvent] = useState(false);
    useEffect(() => {
        UpdateJournals();
    }, []);
    const curentDate = createListOfcurrentDates()
    var selectedFiltersObj = {
        "findline": 'Чайкина',
        "datepicker": 'Чайкина',
        "year": 'Чайкина',
        "semestr": 'Чайкина',
    }
    const years = ['2023-2024', '2022-2023']
    const semesters = ['Весна', 'Осень']
    
    const [selectedFilters, setSelectedFilters] = useState(selectedFiltersObj)
    const contents = journals === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        :<div className={styles.ListOfJournals} >
            <div style={{ display: "flex", width: '100%', flexDirection: 'row' }}>
                <FindLine clickState={click} valueHook={UpdateFindlineFilterValue} />
                <MyDatePicker defaultDate={curentDate} />
                <Filter list={years} onChangeEvent={UpdateYearFilterValue} />
                <Filter list={semesters} onChangeEvent={UpdateSemestrFilterValue} />
                <Button text="Поиск"  onClick={() => {
                    console.log("Button clicked");
                    UpdateJournalsWithFilter(8,0);
                }} />

            </div>
            {journals.map(journal =>

                <PartOfList key={journal.code}
                    prepodName={journal.teacherName}
                    GroupName={journal.GroupName}
                    usercount={journal.studentCount}
                    disciplineName={journal.discipline}
                    attendance={journal.lectionHours}
                    nagr_idList={journal.nagrCode}
                    lectionTypes={journal.lectionType}
                    journal_id={journal.code}
                >
                    </PartOfList>
      
            )}
            
        </div>
    return (
        <div>
            {contents}
            <Paginator currentPage={1} total={200} limit={20} onPageChange={() => UpdateJournalsWithFilter(8,300)}  ></Paginator>
        
        </div>
     
        )
    async function UpdateJournals() {
        const response = await fetch('https://localhost:7256/api/JournalData/GetJornalsHeaders/28&0');
        const data = await response.json();
        setJournals(data);
    }
    async function UpdateJournalsWithFilter(kaf_id,last_id) {
        const response = await fetch('https://localhost:7256/api/JournalData/GetJornalsHeaders/' + kaf_id + '&' + last_id);
        const data = await response.json();
        console.log(data)
        if (data != undefined) {
            setJournals(data);
        }
        else {
            setJournals([]);
        }
    }
    function createListOfcurrentDates() {
        var result = []
        const curentDate = new Date()
        var startdate = new Date()
        var enddate = new Date()
        console.log(curentDate.getMonth > 0)

        if (curentDate.getMonth() > 0 && curentDate.getMonth() < 6) {
            
            startdate.setFullYear(curentDate.getFullYear() - 1, 8, 1)
            enddate.setFullYear(curentDate.getFullYear(),6,1)
        }
        else {
            startdate.setFullYear(curentDate.getFullYear(), 8, 1)
            enddate.setFullYear(curentDate.getFullYear() +1 , 6, 1)
        }

        result.push(startdate, enddate)
        return result;
    }
    function UpdateFindlineFilterValue(val) {
        selectedFiltersObj.findline = val
        console.log(selectedFiltersObj)
        setSelectedFilters(selectedFiltersObj)
    }
    function UpdateDatePickerFilterValue() {

    }
    function UpdateYearFilterValue() {
        
    }
    function UpdateSemestrFilterValue() {

    }
}
function PartOfList({ prepodName, GroupName, usercount, disciplineName, attendance, stat, journal_id, nagr_idList, lectionTypes }) {
    const [AnaliticCardVisible, setVisible] = useState(true);
    const [AnaliticCardData, setData] = useState(new Object());
    async function UpdateJournals(journal_id, nagr_id) {
        const today = new Date().toLocaleDateString("de-DE")
        var response;
        if (AnaliticCardVisible === true) {
            response = await fetch('https://localhost:7256/api/JournalData/GetJornalBody/' + journal_id + '&' + today + '&' + nagr_id);
            const data = await response.json();
            console.log(data)
            setData(data);
        }
    } 
    const handleHideCard = async () => {
        
        var nagr_id = nagr_idList[0];
        UpdateJournals(journal_id, nagr_id).then(
            function () {
                if (AnaliticCardData) {
                    setVisible(!AnaliticCardVisible)
                }
            },
            function (error) {
                console.log(error)
            }
        )     
    };

    return (
        <div style={{ display: "flex", width: '100%', flexDirection: 'column' }}>
            <GoodRowWithData onClick={handleHideCard}
                             prepodName={prepodName}
                             GroupName={GroupName}
                             usercount={usercount}
                             disciplineName={disciplineName}
                             attendance={attendance}
                             stat={stat}
            />
            {!AnaliticCardVisible && (

                <SuperAnaliticCard key={journal_id}
                    data={AnaliticCardData}
                    nagr_idList={nagr_idList}
                    lectionTypes={lectionTypes}/>
            )}
        </div>
    );  
} 
function DoughnutChart({ value }) {
    const containerStyle = {
        width: '50px',
        height: '50px',
    };
    const data = {
        datasets: [
            {
                data: [value, 100 - value],
                backgroundColor: [
                    'black',
                    'white',
                ],
                borderColor: [
                    'white'
                ],
                borderWidth: 1,
            },
        ],
    };
    const options = {
        responsive: true,
        maintainAspectRatio: false,
        width: 130,
        height: 55,
        plugins: {
            datalabels: false, // Removing this line shows the datalabels again
            tooltip: {
                enabled: false
            }
        }
    };
    return (<Doughnut data={data} options={options} />)
};
function SuperAnaliticCard({ nagr_idList, lectionTypes, data }) {
    var zapol = getZapol(data.nagrHours, data.hours)
    var attence = CountNProcent(data.Ncount, data.studentCount, data.hours)

    return (
        <div className={styles.super_analictic}>
            <div className={styles.super_analictic_calendar}>
                <div className={styles.super_analictic_calendar_Button}>
                    {lectionTypes.map(item => <Button text={item}>
                                                    </Button>)}
                </div>
            </div>
            <div className={styles.super_analictic_data}>
                <div className={styles.super_analictic_Card}>
                    <div id='Hours' className={styles.super_analictic_dataCard}>
                        <p id='Hours_text' className={styles.super_analictic_dataCard_text}>{data.hours}</p>
                        <p id='Hours_label' className={styles.super_analictic_dataCard_text2} >часов за период</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>{data.EvalCount}</p>
                        <p className={styles.super_analictic_dataCard_text2} >оценки</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>{data.midleAttence}</p>
                        <p className={styles.super_analictic_dataCard_text2} >Среднее</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>{data.Ncount}</p>
                        <p className={styles.super_analictic_dataCard_text2} >пропуски</p>
                    </div>
                </div>
                <div>
                </div>
                <div className={styles.super_analictic_dataCard_graph_container}>
                    <div className={styles.super_analictic_dataCard_graph}>
                        <div >
                            <DoughnutChart value={zapol} ></DoughnutChart>
                        </div>
                        <p style={{ color: "black" }} >
                            Заполнение журнала
                        </p>
                    </div>
                    <div className={styles.super_analictic_dataCard_graph} >
                        <div >
                            <DoughnutChart value={attence}></DoughnutChart>
                        </div>
                        <p style={{ color: "black" }}>
                             Посещаемость
                        </p>
                    </div>
                </div>
            </div>
        </div>
    )
};
function getTodayDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0');//January is 0!
    var yyyy = today.getFullYear();
    today = mm + '.' + dd + '.' + yyyy;
    return today;
}
function getZapol(nagrHours, hours) {
    return (hours / nagrHours)*100
}
function CountNProcent(ncount, studentcount, hourscount) {
    var allAttence = studentcount * hourscount
    return ((allAttence - ncount) / allAttence) * 100
}
 