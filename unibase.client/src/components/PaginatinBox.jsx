import React from 'react';

function PaginatinBox({ pageCount, updateListFunc, LastId}) {
    content = []
    const paginationMax = 21
    for (var i = 0; i < paginationMax; i++) {
        if (i = 20) {
            content.push(< button text={pageCount} ></button >)
        }
        content.push(< button text={i} ></button >)

    }
  return (
      <div>
          {
              content 
          }
      </div>
  );
}

export default PaginatinBox;