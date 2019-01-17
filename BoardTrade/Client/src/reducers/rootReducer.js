import { combineReducers } from 'redux'
import { connectRouter } from 'connected-react-router'
import loaders from './loadersReducer'
import boardGame from './boardGameReducer'

export default history =>
  combineReducers({
    router: connectRouter(history),
    loaders,
    boardGame
  })
