export const GET_JSON_BY_NAME = 'GET_JSON_BY_NAME'

export function fetchStudentsData(name){
  async () => {
    const response = await fetch(`studentdata/
    GetJsonTableRowData/${name}`);
    const data = await response.json();
    return ({ type: 'FETCH_TABLE_DATA', payload: 
    { data, name } });
  };

}