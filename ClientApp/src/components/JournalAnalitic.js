import styles from "./journal_analitic.module.css"





export default function JournalAnalitic() {
    return (
        <div>
            <Body/>
            <AnaliticCard/>
        </div>
    )

}

function Body() {
    return (
        <>
           
        </>
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
                <h5>23213</h5>
                
            </div>
            <div className={styles.AnaliticCard_body}>
                    <h5>2321322</h5>
                    <h1></h1>
                 </div>
        </div>
    )
   
}
