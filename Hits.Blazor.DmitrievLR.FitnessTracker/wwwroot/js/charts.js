window.renderVolumeChart = (canvasId, labels, data) => {
    const ctx = document.getElementById(canvasId);
    if (!ctx) return;

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Объём тренировки (кг)',
                data: data,
                tension: 0.3
            }]
        },
        options: {
            responsive: true
        }
    });
};
