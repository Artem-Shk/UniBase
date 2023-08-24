import React from 'react';
import { connect } from 'react-redux';
import fetchTableData from '../../actions';

function SearchBar() {
     const handleKeyDown = (event) => {
       if (event.keyCode === 13) {
        
       }
     }
     return (
       <div style={{ height: 46, left: 0 }}>
        <input type='text' onKeyDown={handleKeyDown} />
       </div>
    )
   }


// const mapStateToProps = (state) => ({
//   searchQuery: state.table.searchQuery,
// });

// const mapDispatchToProps = {
//   setSearchQuery,
// };

// export default connect(mapStateToProps, mapDispatchToProps)(SearchBar);

export default SearchBar;