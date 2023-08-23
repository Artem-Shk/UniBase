export const fetchTableData = (name) => 
async (dispatch) => {
    const response = await fetch(`studentdata/
    GetJsonTableRowData/${name}`);
    const data = await response.json();
    dispatch({ type: 'FETCH_TABLE_DATA', payload: 
    { data, name } });
  };
  export default fetchTableData;