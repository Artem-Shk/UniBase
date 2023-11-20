import styles from "./journal_analitic.module.css"





export default function JournalAnalitic() {
    return (
        <div >
            <Body/>
            
        </div>
    )

}

function Body() {
    return (
        <div class = {styles.AnaliticCard_holder}>
            <AnaliticCard/>
            <AnaliticCard/>
            <AnaliticCard/>
            <AnaliticCard/> 
            <AnaliticCard/>
            <AnaliticCard/>
            <AnaliticCard/>
            <AnaliticCard/> 
            <AnaliticCard/>
            <AnaliticCard/>
            <AnaliticCard/>
            <AnaliticCard/> 
        </div>
    )
}
function LeftMenu() {
    return (
        <div>
            
        </div>

    )
} 
function AnaliticCard() {
    return(
        <div className = {styles.AnaliticCard}>
            <div className={styles.AndliticCard_header}>
                <a></a>
                <a>Чипфд-01-20</a>
                <a>Иванов.И.И</a>
                <a>Решение решалок</a>
            </div>

            <div className={styles.AnaliticCard_body}>
                <div class = {styles.AnaliticCard_Fields_card}>
                    <p class = {styles.AnaliticCard_Fields} >Студентов</p>
                    <p class = {styles.AnaliticCard_Fields} >Часов</p>
                    <p class = {styles.AnaliticCard_Fields} >Прошедших часов</p>
                    <p class = {styles.AnaliticCard_Fields} >Кол-во пропусков</p>
                </div>
                   
            </div>
            <div>
                
            </div>
        </div>
    )
   
}
