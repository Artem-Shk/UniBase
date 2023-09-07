

export const GET_JSON_BY_NAME = 'GET_JSON_BY_NAME'
export const ERROR='ERROR'

export function fetchStudentsData(name) {
  return async (dispatch) => {
    try {
      const response = await fetch(`studentdata/GetJsonTableRowData/${name}`);
      if (response.status === 200) {
        const data = await response.json();
        console.log('Успех в экшене');
        dispatch({ type: GET_JSON_BY_NAME, payload: data });
      }
      else{
        console.log(response.status)
        dispatch({type: ERROR, Error_code: response.status})
      }
    } catch (error) {
      console.error(error);
      return -1;
    }
  };
}
export function fetchFaculiesNames() {
  return async (dispatch) => {
    
    try {
      const response = await fetch(`studentdata/GetMenuData/`);
      

      if (response.status === 200) {
        const data = await response.json();
        console.log('Успех в экшене факультетов');
        dispatch({ type: GET_JSON_BY_NAME, payload: data });
      }
      else{
        console.log(response.status)
        dispatch({type: ERROR, Error_code: response.status})
      }
    } catch (error) {
      console.error(error);
      return -1;
    }
  };
}