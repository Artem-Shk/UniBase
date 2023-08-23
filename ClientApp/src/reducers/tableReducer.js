//table reducer save state of table
const initialState = {
  data: [],
  name: '',
};

const tableReducer = (state = initialState, action) => {
  switch (action.type) {
    case 'FETCH_TABLE_DATA':
      return { ...state, data: action.payload.data, name: action.payload.searchTerm };
    default:
      return state;
  }
};
  
  export default tableReducer;