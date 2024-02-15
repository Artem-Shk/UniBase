import styles from "./journal_analitic.module.css"
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
ChartJS.register(ArcElement, Tooltip);
export default function JournalAnalitic() {
    return (
        <ListOfJournals />
    )
}
function Body() {
    return (
        <div className={styles.main_container}>
            <ListOfJournals />
        </div>
    )
}
function LeftMenu() {
    return (
        <div>
        </div>
    )
}
function ListOfJournals() {
    const [journals, setJournals] = useState();
    useEffect(() => {
        UpdateJournals();
    }, []);
    const contents = journals === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        :<div className={styles.ListOfJournals} >
            <div style={{ display: "flex", width: '100%', flexDirection: 'row' }}>
                <FindLine/>
                <MyDatePicker/>
                <Filter/>
            </div>
            {journals.map(journal =>
                <PartOfList key={journal.code}
                            prepodName={journal.teacherName}
                            GroupName={journal.GroupName}
                            usercount={journal.studentCount} 
                            disciplineName={journal.discipline} 
                            attendance={journal.lectionHours} 
                            journal_id={journal.code}
                            >
                </PartOfList>
            )}
        </div>
    return (
        contents
        )
    async function UpdateJournals(kaf_id) {
        const response = await fetch('https://localhost:7256/api/JournalData/GetJornalsHeaders/28');
        const data = await response.json();
        setJournals(data);
    }
}

function PartOfList({ prepodName, GroupName, usercount, disciplineName, attendance, stat,  journal_id }) {
    const [AnaliticCardVisible, setVisible] = useState(true);
    const [AnaliticCardData, setData] = useState(new Object());
    const handleHideCard = async () => {
        UpdateJournals(journal_id).then(
            function (result) {
                if (AnaliticCardData) {
                    setVisible(!AnaliticCardVisible)
                }
            },
            function (error) {
               console.log('not Faggot just like a man')
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
                stat={stat} />
            {!AnaliticCardVisible && (
                <SuperAnaliticCard key={journal_id}
                                   data= {AnaliticCardData}  
                />
            )}
        </div>
    );
    async function UpdateJournals(journal_id) {
        const today = new Date().toLocaleDateString("de-DE")
        var response;
        if (AnaliticCardVisible === true) {
            response = await fetch('https://localhost:7256/api/JournalData/GetJornalBody/' + journal_id + '&' + today);
            const data = await response.json();
            setData(data);
        }
    }
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
function SuperAnaliticCard(data) {
    var zapol = getZapol(data.data.nagrHours, data.data.hours)
    var attence = CountNProcent(data.data.Ncount, data.data.studentCount, data.data.hours)
    return (
        <div className={styles.super_analictic}>
            <div className={styles.super_analictic_calendar}>
                <div className={styles.super_analictic_calendar_Button}>
                    <Button text = 'Всё время'></Button>
                    <Button text='Период' ></Button>
                </div>
                <p className={styles.super_analictic_calendar_text} > 01.06.2023 по {getTodayDate()}</p>
            </div>
            <div className={styles.super_analictic_data}>
                <div className={styles.super_analictic_Card}>
                    <div id='Hours' className={styles.super_analictic_dataCard}>
                        <p id='Hours_text' className={styles.super_analictic_dataCard_text}>{data.data.hours}</p>
                        <p id='Hours_label' className={styles.super_analictic_dataCard_text2} >часов за период</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>{data.data.EvalCount}</p>
                        <p className={styles.super_analictic_dataCard_text2} >оценки</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>{data.data.midleAttence}</p>
                        <p className={styles.super_analictic_dataCard_text2} >Среднее</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>{data.data.Ncount}</p>
                        <p className={styles.super_analictic_dataCard_text2} >пропуски</p>
                    </div>
                </div>
                <div>
                </div>
                <div className={styles.super_analictic_dataCard_graph_container}>
                    <div className={styles.super_analictic_dataCard_graph} >
                        <div >
                            <DoughnutChart value={zapol}></DoughnutChart>
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
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
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
 