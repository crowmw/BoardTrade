import { createBrowserHistory } from 'history'
import { applyMiddleware, createStore } from 'redux'
import { routerMiddleware } from 'connected-react-router'
import thunk from 'redux-thunk'
import { composeWithDevTools } from 'redux-devtools-extension'
import createRootReducer from './reducers/rootReducer'

export const history = createBrowserHistory()

export default preloadedState => {
  const store = createStore(
    createRootReducer(history),
    preloadedState,
    composeWithDevTools(applyMiddleware(routerMiddleware(history), thunk))
  )

  return store
}
