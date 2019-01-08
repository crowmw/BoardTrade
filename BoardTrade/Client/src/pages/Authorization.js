import React, { Component } from 'react'
import styled from 'styled-components'
import Paper from '../components/Paper'
import TextField from '../components/TextField'
import Button from '../components/Button'
import Link from '../components/Link'

const StyledWrapper = styled.div`
  padding: 24px;
  display: flex;
  flex-flow: column;
  align-items: center;
`

const LoginButton = styled(Button)`
  margin: '16px 0';
`

class Authorization extends Component {
  render() {
    return (
      <StyledWrapper>
        <Paper>
          <TextField fullWidth placeholder="Login lub email" />
          <TextField fullWidth placeholder="Hasło" type="password" />
          <LoginButton type="submit" fullWidth>
            Zaloguj się
          </LoginButton>
        </Paper>
        <Paper secondary>
          Nowy na BoardTrade? <Link>Utwórz swoje konto.</Link>
        </Paper>
      </StyledWrapper>
    )
  }
}

export default Authorization
