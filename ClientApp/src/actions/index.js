export const GET_JSON_BY_NAME = 'GET_JSON_BY_NAME'


export function fetchStudentsData(name) {
  return async (dispatch) => {
    try {
      const response = await fetch(`studentdata/GetJsonTableRowData/${name}`);
      const data = await response.json();
      if (response.status === 200) {
        console.log('Успех в экшене');
        dispatch({ type: GET_JSON_BY_NAME, payload: data });
      } else {
        console.log('Ошибка');
        throw new Error('Ошибка получения данных');
      }
    } catch (error) {
      console.error(error);
      return {};
    }
  };
}