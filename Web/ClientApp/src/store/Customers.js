const requestCustomersType = "REQUEST_CUSTOMERS";
const receiveCustomersType = "RECEIVE_CUSTOMERS";
const initialState = { customers: [], isLoading: false };

export const actionCreators = {
  requestCustomers: () => async (dispatch, getState) => {
    dispatch({ type: requestCustomersType });

    const url = `api/Customers`;
    const response = await fetch(url);
    const customers = await response.json();

    // Remove timeout after creating spinner
    setTimeout(() => {
      dispatch({ type: receiveCustomersType, customers });
    }, 5000);
  }
};
export const reducer = (state, action) => {
  state = state || initialState;

  switch (action.type) {
    case requestCustomersType:
      return {
        ...state,
        isLoading: true
      };
    case receiveCustomersType:
      return {
        ...state,
        customers: action.customers,
        isLoading: false
      };
    default:
      return state;
  }
};
