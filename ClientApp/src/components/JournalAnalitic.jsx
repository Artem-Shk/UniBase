﻿import styles from "./journal_analitic.module.css"
import React from 'react';
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';
import { Doughnut } from 'react-chartjs-2';
ChartJS.register(ArcElement, Tooltip, Legend);

export default function JournalAnalitic() {
    return (
        <ListOfJournals/>
    )

}

function Body() {
    return (
        <div  className = {styles.main_container}>
            <ListOfJournals/>
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
        <div style={{display:"flex", width:'100%', flexDirection:'column'}}>
            <PartOfList/>
            <super_analitic_card/>
        </div>    
       
        <PartOfList/>
        <PartOfList/>
    </div>
    )
    
}

function FindLine(){
    return (
        <div className={styles.FindLine}>
            <div className={styles.search_container} >
                <p className={styles.search_container_text}>
                    Преподователь, группа или дисциплина
                </p>
            </div>
        </div>
    )

}

function PartOfList({prepodName,GroupName,usercount,disciplineName,attendance,stat}){
    
    return (

        <div className = {styles.part_ofList}>
            <p className= {styles.font} >Чайкина М. Л.</p>
            <p className= {styles.font} >ЧИПфд-01-20</p>
            <div style={{display: 'flex', margin:0, alignItems:'center'}} >
                <p className={styles.font}>28</p>
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="25" viewBox="0 0 24 25" fill="none">
                    <mask style = {{id:"mask0_378_8656", style:"mask-type:alpha", maskUnits:"userSpaceOnUse"}} >
                        <rect style={{y:"0.5",  fill:"#D9D9D9"}}/>
                    </mask>
                    <g mask="url(#mask0_378_8656)">
                        <path d="M0 18.5V16.925C0 16.2083 0.366667 15.625 1.1 15.175C1.83333 14.725 2.8 14.5 4 14.5C4.21667 14.5 4.425 14.5042 4.625 14.5125C4.825 14.5208 5.01667 14.5417 5.2 14.575C4.96667 14.925 4.79167 15.2917 4.675 15.675C4.55833 16.0583 4.5 16.4583 4.5 16.875V18.5H0ZM6 18.5V16.875C6 16.3417 6.14583 15.8542 6.4375 15.4125C6.72917 14.9708 7.14167 14.5833 7.675 14.25C8.20833 13.9167 8.84583 13.6667 9.5875 13.5C10.3292 13.3333 11.1333 13.25 12 13.25C12.8833 13.25 13.6958 13.3333 14.4375 13.5C15.1792 13.6667 15.8167 13.9167 16.35 14.25C16.8833 14.5833 17.2917 14.9708 17.575 15.4125C17.8583 15.8542 18 16.3417 18 16.875V18.5H6ZM19.5 18.5V16.875C19.5 16.4417 19.4458 16.0333 19.3375 15.65C19.2292 15.2667 19.0667 14.9083 18.85 14.575C19.0333 14.5417 19.2208 14.5208 19.4125 14.5125C19.6042 14.5042 19.8 14.5 20 14.5C21.2 14.5 22.1667 14.7208 22.9 15.1625C23.6333 15.6042 24 16.1917 24 16.925V18.5H19.5ZM8.125 16.5H15.9C15.7333 16.1667 15.2708 15.875 14.5125 15.625C13.7542 15.375 12.9167 15.25 12 15.25C11.0833 15.25 10.2458 15.375 9.4875 15.625C8.72917 15.875 8.275 16.1667 8.125 16.5ZM4 13.5C3.45 13.5 2.97917 13.3042 2.5875 12.9125C2.19583 12.5208 2 12.05 2 11.5C2 10.9333 2.19583 10.4583 2.5875 10.075C2.97917 9.69167 3.45 9.5 4 9.5C4.56667 9.5 5.04167 9.69167 5.425 10.075C5.80833 10.4583 6 10.9333 6 11.5C6 12.05 5.80833 12.5208 5.425 12.9125C5.04167 13.3042 4.56667 13.5 4 13.5ZM20 13.5C19.45 13.5 18.9792 13.3042 18.5875 12.9125C18.1958 12.5208 18 12.05 18 11.5C18 10.9333 18.1958 10.4583 18.5875 10.075C18.9792 9.69167 19.45 9.5 20 9.5C20.5667 9.5 21.0417 9.69167 21.425 10.075C21.8083 10.4583 22 10.9333 22 11.5C22 12.05 21.8083 12.5208 21.425 12.9125C21.0417 13.3042 20.5667 13.5 20 13.5ZM12 12.5C11.1667 12.5 10.4583 12.2083 9.875 11.625C9.29167 11.0417 9 10.3333 9 9.5C9 8.65 9.29167 7.9375 9.875 7.3625C10.4583 6.7875 11.1667 6.5 12 6.5C12.85 6.5 13.5625 6.7875 14.1375 7.3625C14.7125 7.9375 15 8.65 15 9.5C15 10.3333 14.7125 11.0417 14.1375 11.625C13.5625 12.2083 12.85 12.5 12 12.5ZM12 10.5C12.2833 10.5 12.5208 10.4042 12.7125 10.2125C12.9042 10.0208 13 9.78333 13 9.5C13 9.21667 12.9042 8.97917 12.7125 8.7875C12.5208 8.59583 12.2833 8.5 12 8.5C11.7167 8.5 11.4792 8.59583 11.2875 8.7875C11.0958 8.97917 11 9.21667 11 9.5C11 9.78333 11.0958 10.0208 11.2875 10.2125C11.4792 10.4042 11.7167 10.5 12 10.5Z" fill="#0077CC"/>
                    </g>
                </svg>
            </div>
            <p className= {styles.font} >Интернет Вещей</p>
                <div style={{display: 'flex', margin:0}} >
                <div style={{width: '45px', height: '45px'}}>
                    <DoughnutChart style = {{display: 'flex', margin:0}} value ={100} ></DoughnutChart>
                </div >            
            </div>
            
        </div>
       
    )
    
} 

function DoughnutChart({value}){
    
    const containerStyle = {
        width: '50px',
        height: '50px',
      };
    const data = {
       
        datasets: [
          {
            label: '# of Votes',
            data: [value,100 - value ],
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
        width: 45,
        height: 55,
      
      };
  
    return ( <Doughnut data={data} options={options}/>)
  };
function super_analitic_card({}){
    return (
        <div className={styles.super_analictic_data}>
            <div className={styles.super_analictic_calendar}>
                <div>
                    class
                </div>
            </div>
        </div>
    )
}