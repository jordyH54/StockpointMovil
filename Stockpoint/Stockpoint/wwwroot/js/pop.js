function toggleCardDetails(cardId) {
    const allCards = document.querySelectorAll('.grid-card');
    let clickedCard = null;
    let clickedDetails = null;
    let clickedButton = null;
    let wasVisible = false;

    allCards.forEach(card => {
        const details = card.querySelector('.expanded-details');
        const button = card.querySelector('.toggle-btn');
        const isClicked = card.id === `card-${cardId}`;

        if (isClicked) {
            clickedCard = card;
            clickedDetails = details;
            clickedButton = button;
            wasVisible = details.classList.contains('show');
        }

        // Ocultar todas
        details.classList.remove('show');
        button.textContent = '▼';
    });

    // Si no estaba visible, mostrarla
    if (!wasVisible && clickedDetails && clickedButton) {
        clickedDetails.classList.add('show');
        clickedButton.textContent = '▲';
    }
}



