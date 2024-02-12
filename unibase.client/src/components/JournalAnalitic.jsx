import styles from "./journal_analitic.module.css"
import "react-datepicker/dist/react-datepicker.css";
import React, { useEffect, useState } from 'react';

import DatePicker from "react-datepicker";
import { Chart as ChartJS, ArcElement, Tooltip } from 'chart.js';
import { Doughnut } from 'react-chartjs-2';
import Button from './Button'
import GoodRowWithData from './GoodRowWithData'
import MyDatePicker from './MyDatePicker'
ChartJS.register(ArcElement, Tooltip);
var journal_id_default = 0;
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
                <FindLine></FindLine>
                <MyDatePicker />
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
function FindLine() {
    return (
        <div className={styles.FindLine}>
            <div className={styles.search_container} >
            <input type="text" className={styles.search_container_text} />
                <svg xmlns="http://www.w3.org/2000/svg" width="29" height="29" viewBox="0 0 29 29" fill="none">
                    <mask style={{ id: "mask0_378_8642", style: "mask-type:alpha", maskUnits: "userSpaceOnUse" }}>
                        <rect style={{ fill: "#D9D9D9" }} />
                    </mask>
                    <g mask="url(#mask0_378_8642)">
                        <path d="M23.6833 25.375L16.0708 17.7625C15.4667 18.2458 14.7719 18.6285 13.9865 18.9104C13.201 19.1924 12.3653 19.3333 11.4792 19.3333C9.28403 19.3333 7.42622 18.5731 5.90573 17.0526C4.38524 15.5321 3.625 13.6743 3.625 11.4792C3.625 9.28403 4.38524 7.42622 5.90573 5.90573C7.42622 4.38524 9.28403 3.625 11.4792 3.625C13.6743 3.625 15.5321 4.38524 17.0526 5.90573C18.5731 7.42622 19.3333 9.28403 19.3333 11.4792C19.3333 12.3653 19.1924 13.201 18.9104 13.9865C18.6285 14.7719 18.2458 15.4667 17.7625 16.0708L25.375 23.6833L23.6833 25.375ZM11.4792 16.9167C12.9896 16.9167 14.2734 16.388 15.3307 15.3307C16.388 14.2734 16.9167 12.9896 16.9167 11.4792C16.9167 9.96875 16.388 8.6849 15.3307 7.6276C14.2734 6.57031 12.9896 6.04167 11.4792 6.04167C9.96875 6.04167 8.6849 6.57031 7.6276 7.6276C6.57031 8.6849 6.04167 9.96875 6.04167 11.4792C6.04167 12.9896 6.57031 14.2734 7.6276 15.3307C8.6849 16.388 9.96875 16.9167 11.4792 16.9167Z" fill="#828282" />
                    </g>
                </svg>
            </div>
        </div>
    )
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
               console.log('Faggot')
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
 