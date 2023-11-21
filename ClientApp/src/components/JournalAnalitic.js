import styles from "./journal_analitic.module.css"





export default function JournalAnalitic() {
    return (
        <div className={styles.main_container}>
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
                <a  class = {styles.AnaliticCard_Fields}>Чипфд-01-20</a>
                <a  class = {styles.AnaliticCard_Fields}>Иванов.И.И</a>
                <a  class = {styles.AnaliticCard_Fields} >Решение решалок</a>
            </div>

            <div className={styles.AnaliticCard_body}>
                <div class = {styles.AnaliticCard_Fields_card}>
                    <div class = {styles.AnaliticCard_Fields_row}>
                        <p class = {styles.AnaliticCard_Fields}>Студентов:20</p>
                        <p class = {styles.AnaliticCard_Fields} style={{  margin:' 2px auto 2px auto'}}>Часов:20</p>
                        <p class = {styles.AnaliticCard_Fields}>Кол-во пропусков:20</p>
                    </div>
                    <p class = {styles.AnaliticCard_Fields}>Прошедших часов/Количество часов в семестре:20/120</p>
                    
                    <div>
                        
                        <p class = {styles.AnaliticCard_Fields}>процента посещаемости и заполнения:20 из 100</p>
                        <p class = {styles.AnaliticCard_Fields}>количество выставленных оценок:5 </p></div>
                    </div>
                </div>
            <div>
                
            </div>
        </div>
    )
   
}
