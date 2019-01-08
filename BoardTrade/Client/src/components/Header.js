import React from 'react'
import styled from 'styled-components'
import Button from './Button'
import UserIcon from '../assets/img/UserIcon'
import { Link } from 'react-router-dom'

const StyledHeaderWrapper = styled.header`
  display: flex;
  flex-flow: row-reverse;
  height: 50px;
  background: ${({ theme }) => theme.colors.blue};
  top: 0;
`

const Header = () => {
  return (
    <StyledHeaderWrapper>
      <Button as={Link} to="/login" style={{ margin: 0 }}>
        <UserIcon />
      </Button>
    </StyledHeaderWrapper>
  )
}

export default Header
