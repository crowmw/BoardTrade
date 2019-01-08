import styled from 'styled-components'

const Link = styled.a`
  color: ${({ theme }) => theme.colors.blueLight};
  padding: 16px;
  cursor: pointer;
  text-decoration: none;

  :hover {
    text-decoration: underline;
  }
`

export default Link
