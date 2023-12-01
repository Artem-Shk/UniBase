import styles from "./journal_analitic.module.css"
import React, { useState } from 'react';
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';
import { Doughnut } from 'react-chartjs-2';
ChartJS.register(ArcElement, Tooltip, Legend);


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
        return (
            <div className={styles.ListOfJournals} >
                <FindLine></FindLine>
                <div style={{ display: "flex", width: '100%', flexDirection: 'column' }}>
                    <PartOfList />
                </div>
                <PartOfList />
                <PartOfList />
                <PartOfList />
                <PartOfList />
                <PartOfList />
                <PartOfList />
                <PartOfList />
                <PartOfList />
            </div>
        )
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
function PartOfList({ prepodName, GroupName, usercount, disciplineName, attendance, stat }) {
    const [visible, setVisible] = useState('visible');
    return (
        <div style={{ display: "flex", width: '100%', flexDirection: 'column' }}>
            <div className={styles.part_ofList}>
                <p className={styles.font} >Чайкина М. Л.</p>
                <p className={styles.font} >ЧИПфд-01-20</p>
                <div style={{ display: 'flex', margin: 0, alignItems: 'center' }} >
                    <p className={styles.font}>28</p>
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="25" viewBox="0 0 24 25" fill="none">
                        <mask style={{ id: "mask0_378_8656", style: "mask-type:alpha", maskUnits: "userSpaceOnUse" }} >
                            <rect style={{ y: "0.5", fill: "#D9D9D9" }} />
                        </mask>
                        <g mask="url(#mask0_378_8656)">
                            <path d="M0 18.5V16.925C0 16.2083 0.366667 15.625 1.1 15.175C1.83333 14.725 2.8 14.5 4 14.5C4.21667 14.5 4.425 14.5042 4.625 14.5125C4.825 14.5208 5.01667 14.5417 5.2 14.575C4.96667 14.925 4.79167 15.2917 4.675 15.675C4.55833 16.0583 4.5 16.4583 4.5 16.875V18.5H0ZM6 18.5V16.875C6 16.3417 6.14583 15.8542 6.4375 15.4125C6.72917 14.9708 7.14167 14.5833 7.675 14.25C8.20833 13.9167 8.84583 13.6667 9.5875 13.5C10.3292 13.3333 11.1333 13.25 12 13.25C12.8833 13.25 13.6958 13.3333 14.4375 13.5C15.1792 13.6667 15.8167 13.9167 16.35 14.25C16.8833 14.5833 17.2917 14.9708 17.575 15.4125C17.8583 15.8542 18 16.3417 18 16.875V18.5H6ZM19.5 18.5V16.875C19.5 16.4417 19.4458 16.0333 19.3375 15.65C19.2292 15.2667 19.0667 14.9083 18.85 14.575C19.0333 14.5417 19.2208 14.5208 19.4125 14.5125C19.6042 14.5042 19.8 14.5 20 14.5C21.2 14.5 22.1667 14.7208 22.9 15.1625C23.6333 15.6042 24 16.1917 24 16.925V18.5H19.5ZM8.125 16.5H15.9C15.7333 16.1667 15.2708 15.875 14.5125 15.625C13.7542 15.375 12.9167 15.25 12 15.25C11.0833 15.25 10.2458 15.375 9.4875 15.625C8.72917 15.875 8.275 16.1667 8.125 16.5ZM4 13.5C3.45 13.5 2.97917 13.3042 2.5875 12.9125C2.19583 12.5208 2 12.05 2 11.5C2 10.9333 2.19583 10.4583 2.5875 10.075C2.97917 9.69167 3.45 9.5 4 9.5C4.56667 9.5 5.04167 9.69167 5.425 10.075C5.80833 10.4583 6 10.9333 6 11.5C6 12.05 5.80833 12.5208 5.425 12.9125C5.04167 13.3042 4.56667 13.5 4 13.5ZM20 13.5C19.45 13.5 18.9792 13.3042 18.5875 12.9125C18.1958 12.5208 18 12.05 18 11.5C18 10.9333 18.1958 10.4583 18.5875 10.075C18.9792 9.69167 19.45 9.5 20 9.5C20.5667 9.5 21.0417 9.69167 21.425 10.075C21.8083 10.4583 22 10.9333 22 11.5C22 12.05 21.8083 12.5208 21.425 12.9125C21.0417 13.3042 20.5667 13.5 20 13.5ZM12 12.5C11.1667 12.5 10.4583 12.2083 9.875 11.625C9.29167 11.0417 9 10.3333 9 9.5C9 8.65 9.29167 7.9375 9.875 7.3625C10.4583 6.7875 11.1667 6.5 12 6.5C12.85 6.5 13.5625 6.7875 14.1375 7.3625C14.7125 7.9375 15 8.65 15 9.5C15 10.3333 14.7125 11.0417 14.1375 11.625C13.5625 12.2083 12.85 12.5 12 12.5ZM12 10.5C12.2833 10.5 12.5208 10.4042 12.7125 10.2125C12.9042 10.0208 13 9.78333 13 9.5C13 9.21667 12.9042 8.97917 12.7125 8.7875C12.5208 8.59583 12.2833 8.5 12 8.5C11.7167 8.5 11.4792 8.59583 11.2875 8.7875C11.0958 8.97917 11 9.21667 11 9.5C11 9.78333 11.0958 10.0208 11.2875 10.2125C11.4792 10.4042 11.7167 10.5 12 10.5Z" fill="#0077CC" />
                        </g>
                    </svg>
                </div>
                <p className={styles.font} >Интернет Вещей</p>
                <div style={{ display: 'flex', margin: 0 }} >
                    <div style={{ width: '45px', height: '45px' }}>
                        <DoughnutChart style={{ display: 'flex', margin: 0 }} value={100} ></DoughnutChart>
                    </div >
                </div>
            </div>
            <SuperAnaliticCard />
        </div>


    )
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
    };
    return (<Doughnut data={data} options={options} />)
};
function SuperAnaliticCard() {
    return (
        <div className={styles.super_analictic}>
            <div className={styles.super_analictic_calendar}>
                <div className={styles.super_analictic_calendar_Button}>
                    <p className={styles.super_analictic_calendar_Button_text}>всё время</p>
                    <p className={styles.super_analictic_calendar_Button_text_choose}>период</p>
                </div>
                <p className={styles.super_analictic_calendar_text} > 01.06.2023 по 30.09.2024</p>
            </div>
            <div className={styles.super_analictic_data}>
                <div className={styles.super_analictic_Card}>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>120</p>
                        <p className={styles.super_analictic_dataCard_text2} >часов за период</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>112</p>
                        <p className={styles.super_analictic_dataCard_text2} >оценки</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>4.3</p>
                        <p className={styles.super_analictic_dataCard_text2} >Среднее</p>
                    </div>
                    <div className={styles.super_analictic_dataCard}>
                        <p className={styles.super_analictic_dataCard_text}>40</p>
                        <p className={styles.super_analictic_dataCard_text2} >пропуски</p>
                    </div>
                </div>
                <div>

                </div>
                <div className={styles.super_analictic_dataCard_graph_container}>
                    <div className={styles.super_analictic_dataCard_graph} >
                        <div >
                            <DoughnutChart value={40}></DoughnutChart>
                        </div>
                        <p>
                            Заполнение журнала
                        </p>
                    </div>
                    <div className={styles.super_analictic_dataCard_graph} >
                        <div >
                            <DoughnutChart value={50}></DoughnutChart>
                        </div>
                        <p>
                            Заполнение журнала
                        </p>
                    </div>
                </div>

            </div>
        </div>
    )
};
