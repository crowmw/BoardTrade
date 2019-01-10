import { JWT_TOKEN_FETCHING, JWT_TOKEN_FETCHING_SUCCESS } from './actionTypes'
import { push } from 'connected-react-router'
import http from '../utils/api'

const iconURL = `https://lh3.googleusercontent.com/-nR1Hit9Kwg4/AAAAAAAAAAI/AAAAAAAAAAA/AKxrwcYT6BXYtEfF6nflGTNxHkZ75NIm7w/s192-c-mo/photo.jpg`

export const login = (userName, password) => async dispatch => {
  dispatch({ type: JWT_TOKEN_FETCHING })

  const result = await http.post(`https://localhost:44339/api/auth/token`, {
    userName,
    password
  })

  if (result && result.status === 200) {
    const token = result.data.access_token
    localStorage.setItem('token', token)

    if (window.PasswordCredential) {
      let credentials = new window.PasswordCredential({
        id: userName,
        name: userName,
        password,
        iconURL
      })
      let c = await navigator.credentials.create({ password: credentials })
      navigator.credentials.store(c)
    }

    return Promise.all([
      dispatch({ type: JWT_TOKEN_FETCHING_SUCCESS, token }),
      dispatch(push('/'))
    ])
  }
}
