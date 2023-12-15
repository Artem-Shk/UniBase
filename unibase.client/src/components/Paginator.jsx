import React from 'react';
import classNames from "classnames";
import "./pagination.css"
//create list of numbers from start to end example: range(0, 10) return [0,1,2,3,....]
const range = (start, end) => {
    return[...Array(end - start).keys()].map((el)) => el + start);
}
//cut pages use condirions 
const getPagesCut = ({ pagesCount, pagesCutCount, currentPage }) => {
    //const u now what is
    // Math thats js library
    // cell makes less rounding
    const ceiling = Math.ceil(pagescutCount / 2);
    const floor = Math.floor(pagesCutCount / 2);
    console.log("ceiling:", ceiling);
    console.log("floor", floor);

    //conditions all pages < needed value pages return object {start:1 end: allpages + 1 }
    if (pagesCount < pagesCutCount) {
        return { start: 1, end: pagesCount + 1 };
    }
    // 
    else if (currentPage >= 1 && currentPage <= ceiling) {
        return { start: 1, end: pagesCutCount + 1 };
    }
    else if (currentPage + floor >= pagesCount) {
        return { start: pagesCount - pagesCutCount + 1, end: pagesCount + 1 }
    }
    else {
        return { start: currentPage - ceiling + 1, end: currentPage + floor + 1 };
    }
}

const PaginationItem({ page, currentPage, onPageChange, isDisable }) => {
    return (
        <li>
            <span>{page}</span>
        </li>
    )
}
const Pagination({ }) => {
    <ui>
        <PaginationItem></PaginationItem>
    </ui>

}

export default ;